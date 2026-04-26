using System.Diagnostics;
using WebPWrapper.Encoder;

namespace WebPify
{
    public partial class MainWindow : Form
    {
        #region Private fields
        private bool _canRequestCancel = false;
        private bool _requestCancel = false;

        private List<ImageFileReference> _selectedImages = new List<ImageFileReference>();

        private event Action<List<ImageFileReference>> _selectedImagesChanged;

        private LogBuilder _log;
        #endregion

        #region Properties
        public bool BatchConvert
        {
            get => checkBox_batchConvert.Checked;
            set => checkBox_batchConvert.Checked = value;
        }

        public bool ScanSubdirectories
        {
            get => checkBox_scanSubdirectories.Checked;
            set => checkBox_scanSubdirectories.Checked = value;
        }

        public bool ReplaceOriginals
        {
            get => checkBox_replaceOriginals.Checked;
            set => checkBox_replaceOriginals.Checked = value;
        }

        public string SourcePath
        {
            get => textBox_source.Text;
            set => textBox_source.Text = value;
        }

        public string OutputPath
        {
            get => textBox_output.Text;
            set => textBox_output.Text = value;
        }

        public string OutputFolderName
        {
            get
            {
                if (string.IsNullOrEmpty(textBox_defaultOutputFolderName.Text))
                    return "_output";

                return textBox_defaultOutputFolderName.Text;
            }
            set => textBox_defaultOutputFolderName.Text = value;
        }

        public ECompressionType Compression
        {
            get => (ECompressionType)comboBox_compression.SelectedIndex;
            set
            {
                comboBox_compression.SelectedIndex = (int)value;
            }
        }

        public int Quality
        {
            get => trackBar_quality.Value;
            set => trackBar_quality.Value = value;
        }

        public int NearLosslessLevel
        {
            get => trackBar_nearLosslessValue.Value;
            set => trackBar_nearLosslessValue.Value = value;
        }

        public List<ImageFileReference> SelectedImages
        {
            get => _selectedImages;
            set
            {
                // if the value is set to the same as it already is, nothing changed so we can just return
                if (_selectedImages == value)
                    return;

                _selectedImages = value;

                // raise the on changed event
                _selectedImagesChanged?.Invoke(_selectedImages);
            }
        }
        #endregion

        #region Forms methods
        public MainWindow()
        {
            InitializeComponent();

            // initialize the log
            _log = new LogBuilder(textBox_log);

            _log.Log("Application startup.", logVisibility: ELogVisibility.Internal);

            // event subscriptions
            _selectedImagesChanged += OnSelectedImagesChange;
            textBox_log.VisibleChanged += OnLogVisibilityChanged;
            comboBox_compression.SelectedIndexChanged += OnSelectedCompressionTypeChanged;
            textBox_defaultOutputFolderName.TextChanged += OnOutputFolderNameChanged;
            tabControl_main.SelectedIndexChanged += OnSelectedIndexChanged;

            checkedListBox_formats.Items.Clear();
            for (int i = 0; i < Constants.SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var entry = Constants.SUPPORTED_FILE_FORMATS[i].Name;

                checkedListBox_formats.Items.Insert(i, entry);
                checkedListBox_formats.SetItemChecked(i, true);
            }

            Text = $"{Application.ProductName} - {Application.ProductVersion.Split('+')[0]}";

            // hide the clear log button until we go to the log page
            button_clearLog.Visible = false;
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Compression = ECompressionType.Lossy;
        }

        private void MainWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            _log.Log("Application shutdown.", logVisibility: ELogVisibility.Internal);
        }
        #endregion

        #region Public methods
        public bool IsFormatEnabled(ImageFormat format)
        {
            if (checkedListBox_formats.CheckedIndices.Count == 0)
                return true;

            int formatIndex = Array.IndexOf(Constants.SUPPORTED_FILE_FORMATS, format);

            return checkedListBox_formats.CheckedIndices.Contains(formatIndex);
        }
        #endregion

        #region Private methods
        private void SetCanRequestCancel(bool value)
        {
            if (_canRequestCancel == value)
                return;

            _canRequestCancel = value;

            button_cancelConvert.Enabled = _canRequestCancel;
        }

        private List<ImageFileReference> ScanDirectory(string dir)
        {
            var errorCount = 0;
            var searchOptions = ScanSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            List<ImageFileReference> imageReferences = new List<ImageFileReference>();

            _log.Log($"Directory scan started. Scan subdirectories: {ScanSubdirectories}, Path: {dir}", logVisibility: ELogVisibility.Internal);

            for (int i = 0; i < Constants.SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = Constants.SUPPORTED_FILE_FORMATS[i];

                if (!IsFormatEnabled(format))
                    continue;

                // add images from the main file extension
                errorCount += AddImageReferencesFromExtension(dir, format.Extension, searchOptions, ref imageReferences);

                // continue to the next format if the alternate extension is null or empty
                if (string.IsNullOrEmpty(format.AlternateExtension))
                    continue;

                // add images from the alternate extension
                errorCount += AddImageReferencesFromExtension(dir, format.AlternateExtension, searchOptions, ref imageReferences);
            }

            // change the tab to the log windows to show errors
            if (errorCount > 0)
            {
                _log.LogError($"Directory scan completed with errors!", logVisibility: ELogVisibility.Internal);
                tabControl_main.SelectedIndex = 2;
                return new List<ImageFileReference>(); // return an empty list to make sure you cannot convert when there are errors
            }

            _log.Log($"Directory scan completed. Images found: {imageReferences.Count}", logVisibility: ELogVisibility.Internal);

            return imageReferences;
        }

        private int AddImageReferencesFromExtension(string dir, string extension, SearchOption searchOptions, ref List<ImageFileReference> imageReferenceList)
        {
            int errorCount = 0;

            // get each file in the folder with the current extension
            var files = Directory.GetFiles(dir, $"*{extension}", searchOptions);

            for (int j = 0; j < files.Length; j++)
            {
                var imageReference = new ImageFileReference(files[j]);

                // if an image in the list already has the same path, dont add the new one, but log an error
                if (imageReferenceList.Where(x => x.FilePathNoExtension.ToLower() == imageReference.FilePathNoExtension.ToLower()).Any())
                {
                    errorCount++;
                    _log.LogError($"Multiple images with the name '{LogBuilder.FormatAsLink(imageReference.FilePath, imageReference.FileName)}' in folder '{LogBuilder.FormatAsLink(imageReference.DirectoryPath)}'", ELogVisibility.User);
                    _log.LogError($"Multiple images with the name '{imageReference.FileName}' in folder '{imageReference.DirectoryPath}'", ELogVisibility.Internal);
                    continue;
                }

                imageReferenceList.Add(imageReference);
            }

            return errorCount;
        }

        private void UpdateImagesFound(int count)
        {
            if (count > 0)
            {
                if (count > 1)
                    label_imagesFound.Text = $"{count} images found!";
                else
                    label_imagesFound.Text = $"{count} image found!";

                label_imagesFound.ForeColor = Color.DarkGreen;
            }
            else
            {
                label_imagesFound.Text = "No images found!";
                label_imagesFound.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// This methods converts the images to '.webp' and moves them to the correct folders.
        /// </summary>
        private async Task ConvertImagesParallel(Action? onComplete = null)
        {
            try
            {
                var builder = new WebPEncoderBuilder();
                IWebPEncoder encoder;

                switch (Compression)
                {
                    case ECompressionType.Lossless:
                        encoder = builder.CompressionConfig(x => x.Lossless(y => y.Quality(Quality))).Build();
                        break;

                    case ECompressionType.NearLossless:
                        encoder = builder.CompressionConfig(x => x.NearLossless(NearLosslessLevel, y => y.Quality(Quality))).Build();
                        break;

                    default:
                        encoder = builder.CompressionConfig(x => x.Lossy(y => y.Quality(Quality))).Build();
                        break;
                }

                progressBar_convert.Value = 0;
                progressBar_convert.Maximum = _selectedImages.Count;
                progressBar_convert.Update();

                int completedCount = 0;
                var convertedImages = new ImageFileReference[_selectedImages.Count];

                await Task.Factory.StartNew(() => Parallel.For(0, _selectedImages.Count, (i, state) =>
                {
                    convertedImages[i] = new ImageFileReference(_selectedImages[i].FilePathNoExtension + ".webp");

                    // if the converted file already exist at the output path, skip it and note it in the log
                    if (File.Exists(convertedImages[i].FileName))
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            _log.LogError($"File '{convertedImages[i].FilePath}' already exist.");
                            _log.LogError("Image conversion skipped.", ELogVisibility.User);
                        }));

                        return;
                    }

                    try
                    {
                        using (var outputFile = File.Open(convertedImages[i].FilePath, FileMode.Create))
                        {
                            using (var inputFile = File.Open(_selectedImages[i].FilePath, FileMode.Open))
                            {
                                encoder.Encode(inputFile, outputFile);
                            }
                        }
                    }
                    catch (Exception ex) // catch and log any other errors that may occure
                    {
                        Invoke(new MethodInvoker(delegate ()
                        {
                            _log.LogError(ex.Message.Trim());
                            _log.LogError("Image conversion skipped.", ELogVisibility.User);
                        }));

                        return;
                    }

                    var fileToMove = ReplaceOriginals ? _selectedImages[i].FullFileName : convertedImages[i].FullFileName;
                    var sourceDir = Path.GetDirectoryName(SourcePath);
                    var currentImageDir = _selectedImages[i].DirectoryPath;

                    if (string.IsNullOrEmpty(sourceDir) || string.IsNullOrEmpty(currentImageDir))
                        return;

                    var destinationDir = currentImageDir.Replace(sourceDir, OutputPath);
                    var destination = Path.Combine(destinationDir, fileToMove);

                    if (!Directory.Exists(destinationDir))
                        Directory.CreateDirectory(destinationDir);

                    Directory.Move(ReplaceOriginals ? _selectedImages[i].FilePath : convertedImages[i].FilePath, destination);

                    // allows us to set the values of forms elemets from other threads
                    Invoke(new MethodInvoker(delegate ()
                    {
                        completedCount++;

                        _log.Log($"Image {completedCount} of {_selectedImages.Count} complete.", logVisibility: ELogVisibility.User);
                        _log.Log($"    Old: {LogBuilder.FormatAsLink(ReplaceOriginals ? destination : _selectedImages[i].FilePath)}", logVisibility: ELogVisibility.User);
                        _log.Log($"    New: {LogBuilder.FormatAsLink(ReplaceOriginals ? convertedImages[i].FilePath : destination)}", logVisibility: ELogVisibility.User);

                        _log.Log($"Conversion completed: {(ReplaceOriginals ? destination : _selectedImages[i].FilePath)} -> {(ReplaceOriginals ? convertedImages[i].FilePath : destination)}", logVisibility: ELogVisibility.Internal);

                        progressBar_convert.Value = completedCount;
                        progressBar_convert.Update();
                    }));

                    // if the user cancled break the loop
                    if (_requestCancel)
                        state.Break();
                }));

                if (_requestCancel)
                {
                    _requestCancel = false;

                    _log.Log("Canceled by user.", Color.Red);
                }
                else
                {
                    _log.Log("Done!", Color.DarkGreen, ELogVisibility.User);
                }
            }
            catch (Exception ex)
            {
                _log.LogError(ex.Message.Trim());
            }

            onComplete?.Invoke();
        }
        #endregion

        #region Event handlers
        private void OnOutputFolderNameChanged(object? sender, EventArgs e)
        {
            label_emptyFolderNameWarning.Visible = string.IsNullOrEmpty(textBox_defaultOutputFolderName.Text);

            if (!string.IsNullOrEmpty(OutputPath))
            {
                int index = Path.GetFullPath(OutputPath).LastIndexOf(Path.DirectorySeparatorChar);
                OutputPath = Path.Combine(OutputPath.Substring(0, index), OutputFolderName);
            }
        }

        private void OnSelectedCompressionTypeChanged(object? sender, EventArgs e)
        {
            // disable or enable the near lossless level slider based on the currently selected compression type
            label_nearLosslessTitle.Enabled = Compression == ECompressionType.NearLossless;
            label_nearLosslessValue.Enabled = Compression == ECompressionType.NearLossless;
            trackBar_nearLosslessValue.Enabled = Compression == ECompressionType.NearLossless;
        }

        private void OnLogVisibilityChanged(object? sender, EventArgs e)
        {
            // if the textbox is not visible, do nothing
            if (!textBox_log.Visible)
                return;

            // scroll to the very bottom of the text box
            textBox_log.SelectionStart = textBox_log.TextLength;
            textBox_log.ScrollToCaret();
        }

        private void OnSelectedImagesChange(List<ImageFileReference> newSelected)
        {
            UpdateImagesFound(_selectedImages.Count);

            // enable or disable the convert button
            button_convert.Enabled = _selectedImages.Count > 0;

            // focus at the end of each string as that is what is most important
            textBox_source.SelectionStart = SourcePath.Length;
            textBox_output.SelectionStart = OutputPath.Length;
        }

        private void OnSelectedIndexChanged(object? sender, EventArgs e)
        {
            button_clearLog.Visible = tabControl_main.SelectedIndex == 2;
        }
        #endregion

        #region Forms event handlers
        private void button_browse_source_Click(object sender, EventArgs e)
        {
            if (BatchConvert)
                Utility.OpenFolderBrowser(this, (selectedDirectory) =>
                {
                    var paths = ScanDirectory(selectedDirectory);

                    UpdateImagesFound(paths.Count);

                    SourcePath = selectedDirectory;
                    if (string.IsNullOrEmpty(OutputPath))
                        OutputPath = Path.Combine(selectedDirectory, OutputFolderName);

                    SelectedImages = paths;
                });
            else
                Utility.OpenFileBrowser(this, (filePath) =>
                {
                    UpdateImagesFound(1);

                    SourcePath = filePath;

                    ImageFileReference fileRef = new ImageFileReference(filePath);
                    if (string.IsNullOrEmpty(OutputPath))
                        OutputPath = Path.Combine(fileRef.DirectoryPath, OutputFolderName);

                    SelectedImages.Clear();
                    SelectedImages.Add(fileRef);
                    _selectedImagesChanged?.Invoke(SelectedImages); // manually invoke event at the list was not changed directly
                });
        }

        private void checkBox_batchConvert_CheckedChanged(object sender, EventArgs e)
        {
            checkBox_scanSubdirectories.Enabled = BatchConvert;
        }

        private void checkBox_scanSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SourcePath))
                return;

            SelectedImages = ScanDirectory(SourcePath);

            UpdateImagesFound(SelectedImages.Count);
        }

        private void button_browse_output_Click(object sender, EventArgs e)
        {
            Utility.OpenFolderBrowser(this, (selectedDirectory) =>
            {
                OutputPath = Path.Combine(selectedDirectory, OutputFolderName);
            });
        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            // jump to the log tab while converting and disable the tabs
            tabControl_main.SelectedIndex = 2;
            tabControl_main.Enabled = false;

            SetCanRequestCancel(true);

            // disable the button so we can initiate another convert action
            button_convert.Enabled = false;

            _log.Log(BatchConvert ? "Batch convert started." : "Single file convert started.", logVisibility: ELogVisibility.Internal);

            // do conversion
            _ = ConvertImagesParallel(() =>
            {
                _log.Log(BatchConvert ? "Batch convert completed." : "Single file convert completed.", logVisibility: ELogVisibility.Internal);

                SetCanRequestCancel(false);

                // reset source path and output path back to empty strings
                SourcePath = "";
                OutputPath = "";

                UpdateImagesFound(0);

                SelectedImages.Clear();
                _selectedImagesChanged?.Invoke(SelectedImages);

                progressBar_convert.Value = 0;
                progressBar_convert.Update();

                // reenable the tabs
                tabControl_main.Enabled = true;
            });
        }

        private void trackBar_quality_Scroll(object sender, EventArgs e)
        {
            // update the label that displays the value of the quality slider
            label_qualityValue.Text = trackBar_quality.Value.ToString();
        }

        private void trackBar_nearLosslessValue_Scroll(object sender, EventArgs e)
        {
            // update the label that displays the value of the near lossless slider
            label_nearLosslessValue.Text = trackBar_nearLosslessValue.Value.ToString();
        }

        private void checkedListBox_formats_SelectedIndexChanged(object sender, EventArgs e)
        {
            label_noFormatsWarning.Visible = checkedListBox_formats.CheckedIndices.Count == 0;

            // if we are in single select mode or have not specified a source path, we return
            if (!BatchConvert || string.IsNullOrEmpty(SourcePath))
                return;

            // update the currently selected images
            SelectedImages = ScanDirectory(SourcePath);
        }

        private void button_clearLog_Click(object sender, EventArgs e)
        {
            textBox_log.Clear();
        }

        private void button_cancelConvert_Click(object sender, EventArgs e)
        {
            _requestCancel = true;
            SetCanRequestCancel(false);
        }

        private void textBox_log_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            if (e.LinkText != null)
            {
                string fullPath = Path.GetFullPath(e.LinkText);

                bool isFilePath = File.Exists(fullPath);

                string command = isFilePath ? $"/select,{fullPath}" : fullPath;

                Process.Start("explorer.exe", command);
            }
        }
        #endregion
    }
}
