namespace WebPify
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            tabControl_main = new TabControl();
            tab_main = new TabPage();
            label_noFormatsWarning = new Label();
            checkBox_replaceOriginals = new CheckBox();
            checkBox_scanSubdirectories = new CheckBox();
            label_emptyFolderNameWarning = new Label();
            label_formats = new Label();
            checkBox_batchConvert = new CheckBox();
            label_outputFolderName = new Label();
            checkedListBox_formats = new CheckedListBox();
            textBox_defaultOutputFolderName = new TextBox();
            label_imagesFound = new Label();
            label_output = new Label();
            textBox_output = new TextBox();
            button_browse_output = new Button();
            textBox_source = new TextBox();
            label_source = new Label();
            button_browse_source = new Button();
            tab_settings = new TabPage();
            label_nearLosslessTitle = new Label();
            label_nearLosslessValue = new Label();
            trackBar_nearLosslessValue = new TrackBar();
            label_quality = new Label();
            label_compression = new Label();
            comboBox_compression = new ComboBox();
            label_qualityValue = new Label();
            trackBar_quality = new TrackBar();
            tab_log = new TabPage();
            textBox_log = new RichTextBox();
            button_clearLog = new Button();
            button_convert = new Button();
            progressBar_convert = new ProgressBar();
            button_cancelConvert = new Button();
            toolTip_main = new ToolTip(components);
            tabControl_main.SuspendLayout();
            tab_main.SuspendLayout();
            tab_settings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_nearLosslessValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_quality).BeginInit();
            tab_log.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl_main
            // 
            tabControl_main.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl_main.Controls.Add(tab_main);
            tabControl_main.Controls.Add(tab_settings);
            tabControl_main.Controls.Add(tab_log);
            tabControl_main.Location = new Point(0, 0);
            tabControl_main.Margin = new Padding(4, 5, 4, 5);
            tabControl_main.Name = "tabControl_main";
            tabControl_main.SelectedIndex = 0;
            tabControl_main.Size = new Size(974, 628);
            tabControl_main.TabIndex = 0;
            // 
            // tab_main
            // 
            tab_main.Controls.Add(label_noFormatsWarning);
            tab_main.Controls.Add(checkBox_replaceOriginals);
            tab_main.Controls.Add(checkBox_scanSubdirectories);
            tab_main.Controls.Add(label_emptyFolderNameWarning);
            tab_main.Controls.Add(label_formats);
            tab_main.Controls.Add(checkBox_batchConvert);
            tab_main.Controls.Add(label_outputFolderName);
            tab_main.Controls.Add(checkedListBox_formats);
            tab_main.Controls.Add(textBox_defaultOutputFolderName);
            tab_main.Controls.Add(label_imagesFound);
            tab_main.Controls.Add(label_output);
            tab_main.Controls.Add(textBox_output);
            tab_main.Controls.Add(button_browse_output);
            tab_main.Controls.Add(textBox_source);
            tab_main.Controls.Add(label_source);
            tab_main.Controls.Add(button_browse_source);
            tab_main.Location = new Point(4, 34);
            tab_main.Margin = new Padding(4, 5, 4, 5);
            tab_main.Name = "tab_main";
            tab_main.Padding = new Padding(4, 5, 4, 5);
            tab_main.Size = new Size(966, 590);
            tab_main.TabIndex = 0;
            tab_main.Text = "Paths";
            tab_main.UseVisualStyleBackColor = true;
            // 
            // label_noFormatsWarning
            // 
            label_noFormatsWarning.AutoSize = true;
            label_noFormatsWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label_noFormatsWarning.ForeColor = SystemColors.ControlDarkDark;
            label_noFormatsWarning.Location = new Point(9, 290);
            label_noFormatsWarning.Margin = new Padding(4, 0, 4, 0);
            label_noFormatsWarning.Name = "label_noFormatsWarning";
            label_noFormatsWarning.Size = new Size(604, 25);
            label_noFormatsWarning.TabIndex = 15;
            label_noFormatsWarning.Text = "You cannot have no source image formats selected. All will be used instead.";
            label_noFormatsWarning.Visible = false;
            // 
            // checkBox_replaceOriginals
            // 
            checkBox_replaceOriginals.AutoSize = true;
            checkBox_replaceOriginals.Location = new Point(17, 417);
            checkBox_replaceOriginals.Margin = new Padding(4, 5, 4, 5);
            checkBox_replaceOriginals.Name = "checkBox_replaceOriginals";
            checkBox_replaceOriginals.Size = new Size(170, 29);
            checkBox_replaceOriginals.TabIndex = 15;
            checkBox_replaceOriginals.Text = "Replace originals";
            toolTip_main.SetToolTip(checkBox_replaceOriginals, "Replaces original image files with the converted files. Old files will be moved to the output folder instead.");
            checkBox_replaceOriginals.UseVisualStyleBackColor = true;
            // 
            // checkBox_scanSubdirectories
            // 
            checkBox_scanSubdirectories.AutoSize = true;
            checkBox_scanSubdirectories.Checked = true;
            checkBox_scanSubdirectories.CheckState = CheckState.Checked;
            checkBox_scanSubdirectories.Enabled = false;
            checkBox_scanSubdirectories.Location = new Point(167, 83);
            checkBox_scanSubdirectories.Margin = new Padding(4, 5, 4, 5);
            checkBox_scanSubdirectories.Name = "checkBox_scanSubdirectories";
            checkBox_scanSubdirectories.Size = new Size(191, 29);
            checkBox_scanSubdirectories.TabIndex = 14;
            checkBox_scanSubdirectories.Text = "Scan subdirectories";
            toolTip_main.SetToolTip(checkBox_scanSubdirectories, "Scans any subdirectories of the specified folder as well.");
            checkBox_scanSubdirectories.UseVisualStyleBackColor = true;
            checkBox_scanSubdirectories.CheckedChanged += checkBox_scanSubdirectories_CheckedChanged;
            // 
            // label_emptyFolderNameWarning
            // 
            label_emptyFolderNameWarning.AutoSize = true;
            label_emptyFolderNameWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label_emptyFolderNameWarning.ForeColor = SystemColors.ControlDarkDark;
            label_emptyFolderNameWarning.Location = new Point(9, 545);
            label_emptyFolderNameWarning.Margin = new Padding(4, 0, 4, 0);
            label_emptyFolderNameWarning.Name = "label_emptyFolderNameWarning";
            label_emptyFolderNameWarning.Size = new Size(422, 25);
            label_emptyFolderNameWarning.TabIndex = 12;
            label_emptyFolderNameWarning.Text = "This cannot be empty, '_output' will be used instead!";
            label_emptyFolderNameWarning.Visible = false;
            // 
            // label_formats
            // 
            label_formats.AutoSize = true;
            label_formats.Location = new Point(9, 158);
            label_formats.Margin = new Padding(4, 0, 4, 0);
            label_formats.Name = "label_formats";
            label_formats.Size = new Size(191, 25);
            label_formats.TabIndex = 14;
            label_formats.Text = "Source image formats:";
            // 
            // checkBox_batchConvert
            // 
            checkBox_batchConvert.AutoSize = true;
            checkBox_batchConvert.Location = new Point(17, 83);
            checkBox_batchConvert.Margin = new Padding(4, 5, 4, 5);
            checkBox_batchConvert.Name = "checkBox_batchConvert";
            checkBox_batchConvert.Size = new Size(145, 29);
            checkBox_batchConvert.TabIndex = 13;
            checkBox_batchConvert.Text = "Batch convert";
            toolTip_main.SetToolTip(checkBox_batchConvert, "Allows you to select folders instead of single files.");
            checkBox_batchConvert.UseVisualStyleBackColor = true;
            checkBox_batchConvert.CheckedChanged += checkBox_batchConvert_CheckedChanged;
            // 
            // label_outputFolderName
            // 
            label_outputFolderName.AutoSize = true;
            label_outputFolderName.Location = new Point(9, 472);
            label_outputFolderName.Margin = new Padding(4, 0, 4, 0);
            label_outputFolderName.Name = "label_outputFolderName";
            label_outputFolderName.Size = new Size(233, 25);
            label_outputFolderName.TabIndex = 5;
            label_outputFolderName.Text = "Default output folder name:";
            // 
            // checkedListBox_formats
            // 
            checkedListBox_formats.CheckOnClick = true;
            checkedListBox_formats.FormattingEnabled = true;
            checkedListBox_formats.Items.AddRange(new object[] { "test1", "test2", "test3" });
            checkedListBox_formats.Location = new Point(9, 188);
            checkedListBox_formats.Margin = new Padding(4, 5, 4, 5);
            checkedListBox_formats.Name = "checkedListBox_formats";
            checkedListBox_formats.Size = new Size(171, 88);
            checkedListBox_formats.TabIndex = 13;
            toolTip_main.SetToolTip(checkedListBox_formats, "The image formats that will be visible in either single or batch mode.");
            checkedListBox_formats.SelectedIndexChanged += checkedListBox_formats_SelectedIndexChanged;
            // 
            // textBox_defaultOutputFolderName
            // 
            textBox_defaultOutputFolderName.Location = new Point(9, 502);
            textBox_defaultOutputFolderName.Margin = new Padding(4, 5, 4, 5);
            textBox_defaultOutputFolderName.Name = "textBox_defaultOutputFolderName";
            textBox_defaultOutputFolderName.Size = new Size(250, 31);
            textBox_defaultOutputFolderName.TabIndex = 0;
            textBox_defaultOutputFolderName.Text = "_output";
            toolTip_main.SetToolTip(textBox_defaultOutputFolderName, "The name of the folder that is created at the output path.");
            // 
            // label_imagesFound
            // 
            label_imagesFound.AutoSize = true;
            label_imagesFound.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label_imagesFound.ForeColor = Color.FromArgb(192, 0, 0);
            label_imagesFound.Location = new Point(17, 120);
            label_imagesFound.Margin = new Padding(4, 0, 4, 0);
            label_imagesFound.Name = "label_imagesFound";
            label_imagesFound.Size = new Size(133, 25);
            label_imagesFound.TabIndex = 11;
            label_imagesFound.Text = "0 images found";
            // 
            // label_output
            // 
            label_output.AutoSize = true;
            label_output.Location = new Point(9, 338);
            label_output.Margin = new Padding(4, 0, 4, 0);
            label_output.Name = "label_output";
            label_output.Size = new Size(114, 25);
            label_output.TabIndex = 5;
            label_output.Text = "Output path:";
            // 
            // textBox_output
            // 
            textBox_output.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_output.Location = new Point(9, 368);
            textBox_output.Margin = new Padding(4, 5, 4, 5);
            textBox_output.Name = "textBox_output";
            textBox_output.ReadOnly = true;
            textBox_output.Size = new Size(833, 31);
            textBox_output.TabIndex = 4;
            // 
            // button_browse_output
            // 
            button_browse_output.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_browse_output.Location = new Point(850, 364);
            button_browse_output.Margin = new Padding(4, 5, 4, 5);
            button_browse_output.Name = "button_browse_output";
            button_browse_output.Size = new Size(107, 38);
            button_browse_output.TabIndex = 3;
            button_browse_output.Text = "Browse...";
            button_browse_output.UseVisualStyleBackColor = true;
            button_browse_output.Click += button_browse_output_Click;
            // 
            // textBox_source
            // 
            textBox_source.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBox_source.Location = new Point(9, 35);
            textBox_source.Margin = new Padding(4, 5, 4, 5);
            textBox_source.Name = "textBox_source";
            textBox_source.ReadOnly = true;
            textBox_source.Size = new Size(833, 31);
            textBox_source.TabIndex = 2;
            // 
            // label_source
            // 
            label_source.AutoSize = true;
            label_source.Location = new Point(9, 5);
            label_source.Margin = new Padding(4, 0, 4, 0);
            label_source.Name = "label_source";
            label_source.Size = new Size(111, 25);
            label_source.TabIndex = 1;
            label_source.Text = "Source path:";
            // 
            // button_browse_source
            // 
            button_browse_source.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button_browse_source.Location = new Point(850, 31);
            button_browse_source.Margin = new Padding(4, 5, 4, 5);
            button_browse_source.Name = "button_browse_source";
            button_browse_source.Size = new Size(107, 38);
            button_browse_source.TabIndex = 0;
            button_browse_source.Text = "Browse...";
            button_browse_source.UseVisualStyleBackColor = true;
            button_browse_source.Click += button_browse_source_Click;
            // 
            // tab_settings
            // 
            tab_settings.Controls.Add(label_nearLosslessTitle);
            tab_settings.Controls.Add(label_nearLosslessValue);
            tab_settings.Controls.Add(trackBar_nearLosslessValue);
            tab_settings.Controls.Add(label_quality);
            tab_settings.Controls.Add(label_compression);
            tab_settings.Controls.Add(comboBox_compression);
            tab_settings.Controls.Add(label_qualityValue);
            tab_settings.Controls.Add(trackBar_quality);
            tab_settings.Location = new Point(4, 34);
            tab_settings.Margin = new Padding(4, 5, 4, 5);
            tab_settings.Name = "tab_settings";
            tab_settings.Padding = new Padding(4, 5, 4, 5);
            tab_settings.Size = new Size(966, 590);
            tab_settings.TabIndex = 1;
            tab_settings.Text = "Quality";
            tab_settings.UseVisualStyleBackColor = true;
            // 
            // label_nearLosslessTitle
            // 
            label_nearLosslessTitle.AutoSize = true;
            label_nearLosslessTitle.Enabled = false;
            label_nearLosslessTitle.Location = new Point(280, 5);
            label_nearLosslessTitle.Margin = new Padding(4, 0, 4, 0);
            label_nearLosslessTitle.Name = "label_nearLosslessTitle";
            label_nearLosslessTitle.Size = new Size(158, 25);
            label_nearLosslessTitle.TabIndex = 11;
            label_nearLosslessTitle.Text = "Near lossless level:";
            // 
            // label_nearLosslessValue
            // 
            label_nearLosslessValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_nearLosslessValue.Location = new Point(369, 79);
            label_nearLosslessValue.Margin = new Padding(4, 0, 4, 0);
            label_nearLosslessValue.Name = "label_nearLosslessValue";
            label_nearLosslessValue.Size = new Size(501, 25);
            label_nearLosslessValue.TabIndex = 10;
            label_nearLosslessValue.Text = "100";
            label_nearLosslessValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBar_nearLosslessValue
            // 
            trackBar_nearLosslessValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar_nearLosslessValue.BackColor = Color.White;
            trackBar_nearLosslessValue.Enabled = false;
            trackBar_nearLosslessValue.Location = new Point(280, 35);
            trackBar_nearLosslessValue.Margin = new Padding(4, 5, 4, 5);
            trackBar_nearLosslessValue.Maximum = 100;
            trackBar_nearLosslessValue.Name = "trackBar_nearLosslessValue";
            trackBar_nearLosslessValue.Size = new Size(677, 69);
            trackBar_nearLosslessValue.TabIndex = 9;
            trackBar_nearLosslessValue.TickFrequency = 25;
            trackBar_nearLosslessValue.TickStyle = TickStyle.TopLeft;
            trackBar_nearLosslessValue.Value = 100;
            trackBar_nearLosslessValue.Scroll += trackBar_nearLosslessValue_Scroll;
            // 
            // label_quality
            // 
            label_quality.AutoSize = true;
            label_quality.Location = new Point(4, 117);
            label_quality.Margin = new Padding(4, 0, 4, 0);
            label_quality.Name = "label_quality";
            label_quality.Size = new Size(77, 25);
            label_quality.TabIndex = 8;
            label_quality.Text = "Quality: ";
            // 
            // label_compression
            // 
            label_compression.AutoSize = true;
            label_compression.Location = new Point(4, 5);
            label_compression.Margin = new Padding(4, 0, 4, 0);
            label_compression.Name = "label_compression";
            label_compression.Size = new Size(157, 25);
            label_compression.TabIndex = 7;
            label_compression.Text = "Compression type";
            // 
            // comboBox_compression
            // 
            comboBox_compression.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_compression.FormattingEnabled = true;
            comboBox_compression.Items.AddRange(new object[] { "Lossy", "Lossless", "Near Lossless" });
            comboBox_compression.Location = new Point(4, 35);
            comboBox_compression.Margin = new Padding(4, 5, 4, 5);
            comboBox_compression.Name = "comboBox_compression";
            comboBox_compression.Size = new Size(171, 33);
            comboBox_compression.TabIndex = 4;
            // 
            // label_qualityValue
            // 
            label_qualityValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label_qualityValue.Location = new Point(243, 191);
            label_qualityValue.Margin = new Padding(4, 0, 4, 0);
            label_qualityValue.Name = "label_qualityValue";
            label_qualityValue.Size = new Size(476, 25);
            label_qualityValue.TabIndex = 3;
            label_qualityValue.Text = "100";
            label_qualityValue.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // trackBar_quality
            // 
            trackBar_quality.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            trackBar_quality.BackColor = Color.White;
            trackBar_quality.Location = new Point(4, 147);
            trackBar_quality.Margin = new Padding(4, 5, 4, 5);
            trackBar_quality.Maximum = 100;
            trackBar_quality.Name = "trackBar_quality";
            trackBar_quality.Size = new Size(953, 69);
            trackBar_quality.TabIndex = 2;
            trackBar_quality.TickFrequency = 10;
            trackBar_quality.TickStyle = TickStyle.TopLeft;
            trackBar_quality.Value = 100;
            trackBar_quality.Scroll += trackBar_quality_Scroll;
            // 
            // tab_log
            // 
            tab_log.Controls.Add(textBox_log);
            tab_log.Location = new Point(4, 34);
            tab_log.Margin = new Padding(4, 5, 4, 5);
            tab_log.Name = "tab_log";
            tab_log.Size = new Size(966, 590);
            tab_log.TabIndex = 2;
            tab_log.Text = "Log";
            tab_log.UseVisualStyleBackColor = true;
            // 
            // textBox_log
            // 
            textBox_log.BackColor = Color.White;
            textBox_log.DetectUrls = false;
            textBox_log.Dock = DockStyle.Fill;
            textBox_log.Location = new Point(0, 0);
            textBox_log.Margin = new Padding(4, 5, 4, 5);
            textBox_log.Name = "textBox_log";
            textBox_log.ReadOnly = true;
            textBox_log.Size = new Size(966, 590);
            textBox_log.TabIndex = 0;
            textBox_log.TabStop = false;
            textBox_log.Text = "";
            textBox_log.WordWrap = false;
            textBox_log.LinkClicked += textBox_log_LinkClicked;
            // 
            // button_clearLog
            // 
            button_clearLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            button_clearLog.Location = new Point(861, 686);
            button_clearLog.Margin = new Padding(4, 5, 4, 5);
            button_clearLog.Name = "button_clearLog";
            button_clearLog.Size = new Size(100, 40);
            button_clearLog.TabIndex = 1;
            button_clearLog.Text = "Clear log";
            button_clearLog.UseVisualStyleBackColor = true;
            button_clearLog.Click += button_clearLog_Click;
            // 
            // button_convert
            // 
            button_convert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_convert.Enabled = false;
            button_convert.Location = new Point(16, 686);
            button_convert.Margin = new Padding(4, 5, 4, 5);
            button_convert.Name = "button_convert";
            button_convert.Size = new Size(150, 40);
            button_convert.TabIndex = 10;
            button_convert.Text = "Convert";
            button_convert.UseVisualStyleBackColor = true;
            button_convert.Click += button_convert_Click;
            // 
            // progressBar_convert
            // 
            progressBar_convert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            progressBar_convert.Location = new Point(16, 638);
            progressBar_convert.Margin = new Padding(4, 5, 4, 5);
            progressBar_convert.Name = "progressBar_convert";
            progressBar_convert.Size = new Size(945, 38);
            progressBar_convert.TabIndex = 1;
            // 
            // button_cancelConvert
            // 
            button_cancelConvert.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button_cancelConvert.Enabled = false;
            button_cancelConvert.Location = new Point(182, 686);
            button_cancelConvert.Margin = new Padding(4, 5, 4, 5);
            button_cancelConvert.Name = "button_cancelConvert";
            button_cancelConvert.Size = new Size(150, 40);
            button_cancelConvert.TabIndex = 11;
            button_cancelConvert.Text = "Cancel";
            button_cancelConvert.UseVisualStyleBackColor = true;
            button_cancelConvert.Click += button_cancelConvert_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(974, 740);
            Controls.Add(button_clearLog);
            Controls.Add(button_cancelConvert);
            Controls.Add(progressBar_convert);
            Controls.Add(tabControl_main);
            Controls.Add(button_convert);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(650, 800);
            Name = "MainWindow";
            Text = "WebPify";
            FormClosed += MainWindow_FormClosed;
            Load += MainWindow_Load;
            tabControl_main.ResumeLayout(false);
            tab_main.ResumeLayout(false);
            tab_main.PerformLayout();
            tab_settings.ResumeLayout(false);
            tab_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_nearLosslessValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar_quality).EndInit();
            tab_log.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private Button button_browse_source;
        private Button button_browse_output;
        private Button button_convert;
        private CheckBox checkBox_batchConvert;
        private CheckBox checkBox_scanSubdirectories;
        private CheckBox checkBox_replaceOriginals;
        private ComboBox comboBox_compression;
        private Label label_output;
        private Label label_imagesFound;
        private Label label_source;
        private Label label_qualityValue;
        private Label label_outputFolderName;
        private Label label_quality;
        private Label label_compression;
        private Label label_nearLosslessValue;
        private Label label_nearLosslessTitle;
        private ProgressBar progressBar_convert;
        private RichTextBox textBox_log;
        private TabControl tabControl_main;
        private TabPage tab_main;
        private TabPage tab_settings;
        private TabPage tab_log;
        private TextBox textBox_source;
        private TextBox textBox_output;
        private TextBox textBox_defaultOutputFolderName;
        private TrackBar trackBar_quality;
        private TrackBar trackBar_nearLosslessValue;
        private Label label_emptyFolderNameWarning;
        private Label label_formats;
        private CheckedListBox checkedListBox_formats;
        private Label label_noFormatsWarning;
        private Button button_clearLog;
        private Button button_cancelConvert;
        private ToolTip toolTip_main;
    }
}
