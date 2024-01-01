using WebPWrapper.Encoder;

namespace WebPify
{
    public partial class MainWindow : Form
    {
        public enum CompressionTypes { Lossy, Lossless }

        public readonly string[] SUPPORTED_FILE_FORMATS = [".jpg", ".jpeg", ".png"];

        private List<string> _selectedImages = new List<string>();

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

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Compression = CompressionTypes.Lossy;

            textBox_log.VisibleChanged += (sender, e) =>
            {
                if (textBox_log.Visible)
                {
                    textBox_log.SelectionStart = textBox_log.TextLength;
                    textBox_log.ScrollToCaret();
                }
            };
        }

        private List<string> ScanDirectory(string dir)
        {
            var searchOptions = ScanSubdirectories ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            List<string> result = new List<string>();

            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var files = Directory.GetFiles(dir, $"*{SUPPORTED_FILE_FORMATS[i]}", searchOptions);

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

        private void Log(string logEntry = "")
        {
            if (logEntry == "")
                textBox_log.AppendText("\n");
            else
                textBox_log.AppendText(logEntry + "\n");
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

            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                filter += $"*{SUPPORTED_FILE_FORMATS[i]}";

                if (i < SUPPORTED_FILE_FORMATS.Length - 1)
                    filter += ", ";
            }
            filter += ")|";
            for (int i = 0; i < SUPPORTED_FILE_FORMATS.Length; i++)
            {
                filter += $"*{SUPPORTED_FILE_FORMATS[i]}";

                if (i < SUPPORTED_FILE_FORMATS.Length - 1)
                    filter += ";";
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
        private void ConvertImages()
        {
            tabControl_main.Enabled = true;

            var builder = new WebPEncoderBuilder();
            IWebPEncoder encoder;

            switch (Compression)
            {
                case CompressionTypes.Lossless:
                    encoder = builder.CompressionConfig(x => x.Lossless(y => y.Quality(Quality))).Build();
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
                int lastDotIndex = _selectedImages[i].LastIndexOf('.');
                var converted = _selectedImages[i].Substring(0, lastDotIndex) + ".webp";

                using (var outputFile = File.Open(converted, FileMode.Create))
                {
                    using (var inputFile = File.Open(_selectedImages[i], FileMode.Open))
                    {
                        encoder.Encode(inputFile, outputFile);
                    }
                }

                var destinationPath = ReplaceOriginals ? _selectedImages[i].Replace(SourcePath, OutputPath) : converted.Replace(SourcePath, OutputPath);
                var destinationDir = Path.GetDirectoryName(destinationPath);

                Directory.CreateDirectory(destinationDir);
                Directory.Move(ReplaceOriginals ? _selectedImages[i] : converted, destinationPath);

                Log($"Image {i + 1} of {_selectedImages.Count} complete.");
                Log($"    Original: {(ReplaceOriginals ? destinationPath : _selectedImages[i])}");
                Log($"    New: {(ReplaceOriginals ? converted : destinationPath)}");

                progressBar_convert.Value = i + 1;
                progressBar_convert.Update();
            }

            Log();
            Log($"Done");
            Log();

            SourcePath = "";
            OutputPath = "";

            UpdateImagesFound(0);

            tabControl_main.Enabled = true;
        }

        private void button_browse_source_Click(object sender, EventArgs e)
        {
            if (BatchConvert)
                OpenFolderBrowser((selectedDirectory) =>
                {
                    var paths = ScanDirectory(selectedDirectory);

                    UpdateImagesFound(paths.Count);

                    SourcePath = selectedDirectory;

                    _selectedImages = paths;

                    OutputPath = Path.Combine(selectedDirectory, textBox_defaultOutputFolderName.Text);
                });
            else
                OpenFileBrowser((filePath) =>
                {
                    UpdateImagesFound(1);

                    SourcePath = filePath;

                    _selectedImages.Clear();
                    _selectedImages.Add(filePath);

                    OutputPath = Path.Combine(Path.GetDirectoryName(filePath), textBox_defaultOutputFolderName.Text);
                });
        }

        private void checkBox_batchConvert_CheckedChanged(object sender, EventArgs e)
        {
            if (BatchConvert)
            {
                checkBox_scanSubdirectories.Enabled = true;
            }
            else
            {
                checkBox_scanSubdirectories.Enabled = false;
            }
        }

        private void checkBox_scanSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            if (BatchConvert && !string.IsNullOrEmpty(SourcePath))
            {
                _selectedImages = ScanDirectory(SourcePath);

                UpdateImagesFound(_selectedImages.Count);
            }
        }

        private void button_browse_output_Click(object sender, EventArgs e)
        {
            OpenFolderBrowser((selectedDirectory) =>
            {
                OutputPath = selectedDirectory;

            });
        }

        private void button_convert_Click(object sender, EventArgs e)
        {
            // jump to the log tab while converting
            tabControl_main.SelectedIndex = 2;

            // do convertion
            ConvertImages();
        }

        private void trackBar_quality_Scroll(object sender, EventArgs e)
        {
            label_qualityValue.Text = trackBar_quality.Value.ToString();
        }

        private void textBox_source_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SourcePath))
                button_convert.Enabled = false;
            else if (!string.IsNullOrEmpty(OutputPath))
                button_convert.Enabled = true;
        }

        private void textBox_output_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(OutputPath))
                button_convert.Enabled = false;
            else if (!string.IsNullOrEmpty(SourcePath))
                button_convert.Enabled = true;
        }
    }
}
