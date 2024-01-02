using System.Diagnostics;
using WebPWrapper.Encoder;

namespace WebPify
{
    public partial class MainWindow : Form
    {
        #region Structs
        private struct ImageFormat
        {
            public string Name;
            public string Extension;
            public string AlternateExtension;
        }
        #endregion

        #region Enums
        public enum CompressionTypes { Lossy, Lossless, NearLossless }
        #endregion

        #region Private fields
        private bool _canCancel = false;
        private bool _cancel = false;

        private readonly ImageFormat[] SUPPORTED_FILE_FORMATS = [FORMAT_JPG, FORMAT_PNG, FORMAT_TIFF];
        private Dictionary<int, ImageFormat> _formatIndexDict = new Dictionary<int, ImageFormat>();

        private List<string> _selectedImages = new List<string>();

        private event Action<List<string>> _selectedImagesChanged;

        private static readonly ImageFormat FORMAT_PNG = new ImageFormat()
        {
            Name = "PNG",
            Extension = ".png"
        };

        private static readonly ImageFormat FORMAT_JPG = new ImageFormat()
        {
            Name = "JPG/JPEG",
            Extension = ".jpg",
            AlternateExtension = ".jpeg"
        };

        private static readonly ImageFormat FORMAT_TIFF = new ImageFormat()
        {
            Name = "TIFF",
            Extension = ".tiff"
        };
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

        public CompressionTypes Compression
        {
            get => (CompressionTypes)comboBox_compression.SelectedIndex;
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

        public List<string> SelectedImages
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

        private bool CanCancel
        {
            get => _canCancel;
            set
            {
                if (_canCancel == value)
                    return;

                _canCancel = value;

                button_cancelConvert.Enabled = _canCancel;
            }
        }
        #endregion

        #region Forms methods
        public MainWindow()
        {
            InitializeComponent();

            // event subscriptions
            _selectedImagesChanged += OnSelectedImagesChange;
            textBox_log.VisibleChanged += OnLogVisibilityChanged;
            comboBox_compression.SelectedIndexChanged += OnSelectedCompressionTypeChanged;
            textBox_defaultOutputFolderName.TextChanged += OnOutputFolderNameChanged;

            checkedListBox_formats.Items.Clear();
            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var entry = SUPPORTED_FILE_FORMATS[i].Name;

                checkedListBox_formats.Items.Insert(i, entry);
                checkedListBox_formats.SetItemChecked(i, true);
            }
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Compression = CompressionTypes.Lossy;
        }
        #endregion

        #region Private methods
        private bool IsFormatEnabled(ImageFormat format)
        {
            if (checkedListBox_formats.CheckedIndices.Count == 0)
                return true;

            int formatIndex = Array.IndexOf(SUPPORTED_FILE_FORMATS, format);

            return checkedListBox_formats.CheckedIndices.Contains(formatIndex);
        }

        private List<string> ScanDirectory(string dir)
        {
            var searchOptions = ScanSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            List<string> result = new List<string>();

            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = SUPPORTED_FILE_FORMATS[i];

                if (!IsFormatEnabled(format))
                    continue;

                // get each file in the folder with the current extension
                var files = Directory.GetFiles(dir, $"*{format.Extension}", searchOptions);

                for (int j = 0; j < files.Length; j++)
                {
                    result.Add(files[j]);
                }

                // continue to the next format if the alternate extension is null or empty
                if (string.IsNullOrEmpty(format.AlternateExtension))
                    continue;

                // do the same for the alternate extension
                files = Directory.GetFiles(dir, $"*{format.AlternateExtension}", searchOptions);

                for (int j = 0; j < files.Length; j++)
                {
                    result.Add(files[j]);
                }
            }

            return result;
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

        private void Log(string logEntry = "", Color? color = null)
        {
            if (color == null)
                color = Color.Black;

            textBox_log.SuspendLayout();
            textBox_log.SelectionColor = color.Value;

            if (logEntry == "")
                textBox_log.AppendText(Environment.NewLine);
            else
                textBox_log.AppendText(logEntry + Environment.NewLine);

            textBox_log.ScrollToCaret();
            textBox_log.ResumeLayout();
        }

        private void OpenFolderBrowser(Action<string> onComplete)
        {
            var dialogue = new FolderBrowserDialog();

            var result = dialogue.ShowDialog();

            if (result == DialogResult.OK)
            {
                onComplete?.Invoke(dialogue.SelectedPath);
            }
        }

        private void OpenFileBrowser(Action<string> onComplete)
        {
            var dialogue = new OpenFileDialog();

            string filter = "Images files (";

            bool isFirst = true;
            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = SUPPORTED_FILE_FORMATS[i];

                if (!IsFormatEnabled(format))
                    continue;

                if (isFirst)
                    isFirst = false;
                else
                    filter += ", ";

                filter += $"{format.Name}";
            }
            isFirst = true;
            filter += ")|";
            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = SUPPORTED_FILE_FORMATS[i];

                if (!IsFormatEnabled(format))
                    continue;

                if (isFirst)
                    isFirst = false;
                else
                    filter += ";";

                filter += $"*{format.Extension}";

                if (!string.IsNullOrEmpty(format.AlternateExtension))
                    filter += $";*{format.AlternateExtension}";
            }

            dialogue.Filter = filter;

            var result = dialogue.ShowDialog();

            if (result == DialogResult.OK)
            {
                onComplete?.Invoke(dialogue.FileName);
            }
        }

        /// <summary>
        /// This methods converts the images to '.webp' and moves them to the correct folders.
        /// </summary>
        private async void ConvertImages(Action onComplete = null)
        {
            try
            {
                var builder = new WebPEncoderBuilder();
                IWebPEncoder encoder;

                switch (Compression)
                {
                    case CompressionTypes.Lossless:
                        encoder = builder.CompressionConfig(x => x.Lossless(y => y.Quality(Quality))).Build();
                        break;

                    case CompressionTypes.NearLossless:
                        encoder = builder.CompressionConfig(x => x.NearLossless(NearLosslessLevel, y => y.Quality(Quality))).Build();
                        break;

                    default:
                        encoder = builder.CompressionConfig(x => x.Lossy(y => y.Quality(Quality))).Build();
                        break;
                }

                progressBar_convert.Value = 0;
                progressBar_convert.Maximum = _selectedImages.Count;
                progressBar_convert.Update();

                for (int i = 0; i < _selectedImages.Count; i++)
                {
                    if (_cancel)
                    {
                        _cancel = false;

                        Log();
                        Log("Canceled by user", Color.Red);
                        Log();

                        onComplete?.Invoke();
                        return;
                    }

                    int lastDotIndex = _selectedImages[i].LastIndexOf('.');
                    var converted = _selectedImages[i].Substring(0, lastDotIndex) + ".webp";

                    await Task.Run(() =>
                    {
                        using (var outputFile = File.Open(converted, FileMode.Create))
                        {
                            using (var inputFile = File.Open(_selectedImages[i], FileMode.Open))
                            {
                                encoder.Encode(inputFile, outputFile);
                            }
                        }
                    });

                    var fileToMove = ReplaceOriginals ? Path.GetFileName(_selectedImages[i]) : Path.GetFileName(converted);
                    var sourceDir = Path.GetDirectoryName(SourcePath);
                    var currentImageDir = Path.GetDirectoryName(_selectedImages[i]);
                    var destinationDir = currentImageDir.Replace(sourceDir, OutputPath);
                    var destination = Path.Combine(destinationDir, fileToMove);

                    Debug.WriteLine("Destination: " + destination);
                    Debug.WriteLine("From: " + (ReplaceOriginals ? _selectedImages[i] : converted));

                    if (!Directory.Exists(destinationDir))
                        Directory.CreateDirectory(destinationDir);

                    Directory.Move(ReplaceOriginals ? _selectedImages[i] : converted, destination);

                    Log($"Image {i + 1} of {_selectedImages.Count} complete.");
                    Log($"    Old: {(ReplaceOriginals ? destination : _selectedImages[i])}");
                    Log($"    New: {(ReplaceOriginals ? converted : destination)}");

                    progressBar_convert.Value = i + 1;
                    progressBar_convert.Update();
                }

                Log();
                Log("Done", Color.DarkGreen);
                Log();
            }
            catch (Exception ex)
            {
                Log();
                Log(ex.Message.Trim(), Color.Red);
                Log();

                onComplete?.Invoke();
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
            label_nearLosslessTitle.Enabled = Compression == CompressionTypes.NearLossless;
            label_nearLosslessValue.Enabled = Compression == CompressionTypes.NearLossless;
            trackBar_nearLosslessValue.Enabled = Compression == CompressionTypes.NearLossless;
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

        private void OnSelectedImagesChange(List<string> newSelected)
        {
            UpdateImagesFound(_selectedImages.Count);

            // enable or disable the convert button
            button_convert.Enabled = _selectedImages.Count > 0;

            // focus at the end of each string as that is what is most important
            textBox_source.SelectionStart = SourcePath.Length;
            textBox_output.SelectionStart = OutputPath.Length;
        }
        #endregion

        #region Forms event handlers
        private void button_browse_source_Click(object sender, EventArgs e)
        {
            if (BatchConvert)
                OpenFolderBrowser((selectedDirectory) =>
                {
                    var paths = ScanDirectory(selectedDirectory);

                    UpdateImagesFound(paths.Count);

                    SourcePath = selectedDirectory;
                    if (string.IsNullOrEmpty(OutputPath))
                        OutputPath = Path.Combine(selectedDirectory, OutputFolderName);

                    SelectedImages = paths;
                });
            else
                OpenFileBrowser((filePath) =>
                {
                    UpdateImagesFound(1);

                    SourcePath = filePath;
                    if (string.IsNullOrEmpty(OutputPath))
                        OutputPath = Path.Combine(Path.GetDirectoryName(filePath), OutputFolderName);

                    SelectedImages.Clear();
                    SelectedImages.Add(filePath);
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
            OpenFolderBrowser((selectedDirectory) =>
            {
                OutputPath = Path.Combine(selectedDirectory, OutputFolderName);
            });
        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            // jump to the log tab while converting and disable the tabs
            tabControl_main.SelectedIndex = 2;
            tabControl_main.Enabled = false;

            CanCancel = true;

            // disable the button so we can initiate another convert action
            button_convert.Enabled = false;

            // do convertion
            ConvertImages(() =>
            {
                CanCancel = false;

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
        #endregion

        private void button_cancelConvert_Click(object sender, EventArgs e)
        {
            _cancel = true;
            CanCancel = false;
        }
    }
}
