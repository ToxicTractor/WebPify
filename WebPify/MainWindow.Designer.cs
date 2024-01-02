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
            button_clearLog = new Button();
            textBox_log = new RichTextBox();
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
            tabControl_main.Controls.Add(tab_main);
            tabControl_main.Controls.Add(tab_settings);
            tabControl_main.Controls.Add(tab_log);
            tabControl_main.Location = new Point(12, 12);
            tabControl_main.Name = "tabControl_main";
            tabControl_main.SelectedIndex = 0;
            tabControl_main.Size = new Size(425, 407);
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
            tab_main.Location = new Point(4, 24);
            tab_main.Name = "tab_main";
            tab_main.Padding = new Padding(3);
            tab_main.Size = new Size(417, 379);
            tab_main.TabIndex = 0;
            tab_main.Text = "Paths";
            tab_main.UseVisualStyleBackColor = true;
            // 
            // label_noFormatsWarning
            // 
            label_noFormatsWarning.AutoSize = true;
            label_noFormatsWarning.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label_noFormatsWarning.ForeColor = SystemColors.ControlDarkDark;
            label_noFormatsWarning.Location = new Point(6, 174);
            label_noFormatsWarning.Name = "label_noFormatsWarning";
            label_noFormatsWarning.Size = new Size(401, 15);
            label_noFormatsWarning.TabIndex = 15;
            label_noFormatsWarning.Text = "You cannot have no source image formats selected. All will be used instead.";
            label_noFormatsWarning.Visible = false;
            // 
            // checkBox_replaceOriginals
            // 
            checkBox_replaceOriginals.AutoSize = true;
            checkBox_replaceOriginals.Location = new Point(12, 250);
            checkBox_replaceOriginals.Name = "checkBox_replaceOriginals";
            checkBox_replaceOriginals.Size = new Size(115, 19);
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
            checkBox_scanSubdirectories.Location = new Point(117, 50);
            checkBox_scanSubdirectories.Name = "checkBox_scanSubdirectories";
            checkBox_scanSubdirectories.Size = new Size(128, 19);
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
            label_emptyFolderNameWarning.Location = new Point(6, 327);
            label_emptyFolderNameWarning.Name = "label_emptyFolderNameWarning";
            label_emptyFolderNameWarning.Size = new Size(282, 15);
            label_emptyFolderNameWarning.TabIndex = 12;
            label_emptyFolderNameWarning.Text = "This cannot be empty, '_output' will be used instead!";
            label_emptyFolderNameWarning.Visible = false;
            // 
            // label_formats
            // 
            label_formats.AutoSize = true;
            label_formats.Location = new Point(6, 95);
            label_formats.Name = "label_formats";
            label_formats.Size = new Size(126, 15);
            label_formats.TabIndex = 14;
            label_formats.Text = "Source image formats:";
            // 
            // checkBox_batchConvert
            // 
            checkBox_batchConvert.AutoSize = true;
            checkBox_batchConvert.Location = new Point(12, 50);
            checkBox_batchConvert.Name = "checkBox_batchConvert";
            checkBox_batchConvert.Size = new Size(99, 19);
            checkBox_batchConvert.TabIndex = 13;
            checkBox_batchConvert.Text = "Batch convert";
            toolTip_main.SetToolTip(checkBox_batchConvert, "Allows you to select folders instead of single files.");
            checkBox_batchConvert.UseVisualStyleBackColor = true;
            checkBox_batchConvert.CheckedChanged += checkBox_batchConvert_CheckedChanged;
            // 
            // label_outputFolderName
            // 
            label_outputFolderName.AutoSize = true;
            label_outputFolderName.Location = new Point(6, 283);
            label_outputFolderName.Name = "label_outputFolderName";
            label_outputFolderName.Size = new Size(154, 15);
            label_outputFolderName.TabIndex = 5;
            label_outputFolderName.Text = "Default output folder name:";
            // 
            // checkedListBox_formats
            // 
            checkedListBox_formats.CheckOnClick = true;
            checkedListBox_formats.FormattingEnabled = true;
            checkedListBox_formats.Items.AddRange(new object[] { "test1", "test2", "test3" });
            checkedListBox_formats.Location = new Point(6, 113);
            checkedListBox_formats.Name = "checkedListBox_formats";
            checkedListBox_formats.Size = new Size(121, 58);
            checkedListBox_formats.TabIndex = 13;
            toolTip_main.SetToolTip(checkedListBox_formats, "The image formats that will be visible in either single or batch mode.");
            checkedListBox_formats.SelectedIndexChanged += checkedListBox_formats_SelectedIndexChanged;
            // 
            // textBox_defaultOutputFolderName
            // 
            textBox_defaultOutputFolderName.Location = new Point(6, 301);
            textBox_defaultOutputFolderName.Name = "textBox_defaultOutputFolderName";
            textBox_defaultOutputFolderName.Size = new Size(176, 23);
            textBox_defaultOutputFolderName.TabIndex = 0;
            textBox_defaultOutputFolderName.Text = "_output";
            toolTip_main.SetToolTip(textBox_defaultOutputFolderName, "The name of the folder that is created at the output path.");
            // 
            // label_imagesFound
            // 
            label_imagesFound.AutoSize = true;
            label_imagesFound.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            label_imagesFound.ForeColor = Color.FromArgb(192, 0, 0);
            label_imagesFound.Location = new Point(12, 72);
            label_imagesFound.Name = "label_imagesFound";
            label_imagesFound.Size = new Size(88, 15);
            label_imagesFound.TabIndex = 11;
            label_imagesFound.Text = "0 images found";
            // 
            // label_output
            // 
            label_output.AutoSize = true;
            label_output.Location = new Point(6, 203);
            label_output.Name = "label_output";
            label_output.Size = new Size(75, 15);
            label_output.TabIndex = 5;
            label_output.Text = "Output path:";
            // 
            // textBox_output
            // 
            textBox_output.Location = new Point(6, 221);
            textBox_output.Name = "textBox_output";
            textBox_output.ReadOnly = true;
            textBox_output.Size = new Size(324, 23);
            textBox_output.TabIndex = 4;
            // 
            // button_browse_output
            // 
            button_browse_output.Location = new Point(336, 221);
            button_browse_output.Name = "button_browse_output";
            button_browse_output.Size = new Size(75, 23);
            button_browse_output.TabIndex = 3;
            button_browse_output.Text = "Browse...";
            button_browse_output.UseVisualStyleBackColor = true;
            button_browse_output.Click += button_browse_output_Click;
            // 
            // textBox_source
            // 
            textBox_source.Location = new Point(6, 21);
            textBox_source.Name = "textBox_source";
            textBox_source.ReadOnly = true;
            textBox_source.Size = new Size(324, 23);
            textBox_source.TabIndex = 2;
            // 
            // label_source
            // 
            label_source.AutoSize = true;
            label_source.Location = new Point(6, 3);
            label_source.Name = "label_source";
            label_source.Size = new Size(73, 15);
            label_source.TabIndex = 1;
            label_source.Text = "Source path:";
            // 
            // button_browse_source
            // 
            button_browse_source.Location = new Point(336, 21);
            button_browse_source.Name = "button_browse_source";
            button_browse_source.Size = new Size(75, 23);
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
            tab_settings.Location = new Point(4, 24);
            tab_settings.Name = "tab_settings";
            tab_settings.Padding = new Padding(3);
            tab_settings.Size = new Size(417, 379);
            tab_settings.TabIndex = 1;
            tab_settings.Text = "Quality";
            tab_settings.UseVisualStyleBackColor = true;
            // 
            // label_nearLosslessTitle
            // 
            label_nearLosslessTitle.AutoSize = true;
            label_nearLosslessTitle.Enabled = false;
            label_nearLosslessTitle.Location = new Point(196, 3);
            label_nearLosslessTitle.Name = "label_nearLosslessTitle";
            label_nearLosslessTitle.Size = new Size(104, 15);
            label_nearLosslessTitle.TabIndex = 11;
            label_nearLosslessTitle.Text = "Near lossless level:";
            // 
            // label_nearLosslessValue
            // 
            label_nearLosslessValue.AutoSize = true;
            label_nearLosslessValue.Location = new Point(289, 51);
            label_nearLosslessValue.Name = "label_nearLosslessValue";
            label_nearLosslessValue.Size = new Size(25, 15);
            label_nearLosslessValue.TabIndex = 10;
            label_nearLosslessValue.Text = "100";
            // 
            // trackBar_nearLosslessValue
            // 
            trackBar_nearLosslessValue.BackColor = Color.White;
            trackBar_nearLosslessValue.Enabled = false;
            trackBar_nearLosslessValue.Location = new Point(196, 21);
            trackBar_nearLosslessValue.Maximum = 100;
            trackBar_nearLosslessValue.Name = "trackBar_nearLosslessValue";
            trackBar_nearLosslessValue.Size = new Size(212, 45);
            trackBar_nearLosslessValue.TabIndex = 9;
            trackBar_nearLosslessValue.TickFrequency = 25;
            trackBar_nearLosslessValue.TickStyle = TickStyle.TopLeft;
            trackBar_nearLosslessValue.Value = 100;
            trackBar_nearLosslessValue.Scroll += trackBar_nearLosslessValue_Scroll;
            // 
            // label_quality
            // 
            label_quality.AutoSize = true;
            label_quality.Location = new Point(3, 70);
            label_quality.Name = "label_quality";
            label_quality.Size = new Size(51, 15);
            label_quality.TabIndex = 8;
            label_quality.Text = "Quality: ";
            // 
            // label_compression
            // 
            label_compression.AutoSize = true;
            label_compression.Location = new Point(3, 3);
            label_compression.Name = "label_compression";
            label_compression.Size = new Size(103, 15);
            label_compression.TabIndex = 7;
            label_compression.Text = "Compression type";
            // 
            // comboBox_compression
            // 
            comboBox_compression.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_compression.FormattingEnabled = true;
            comboBox_compression.Items.AddRange(new object[] { "Lossy", "Lossless", "Near Lossless" });
            comboBox_compression.Location = new Point(3, 21);
            comboBox_compression.Name = "comboBox_compression";
            comboBox_compression.Size = new Size(121, 23);
            comboBox_compression.TabIndex = 4;
            // 
            // label_qualityValue
            // 
            label_qualityValue.AutoSize = true;
            label_qualityValue.Location = new Point(196, 118);
            label_qualityValue.Name = "label_qualityValue";
            label_qualityValue.Size = new Size(25, 15);
            label_qualityValue.TabIndex = 3;
            label_qualityValue.Text = "100";
            // 
            // trackBar_quality
            // 
            trackBar_quality.BackColor = Color.White;
            trackBar_quality.Location = new Point(3, 88);
            trackBar_quality.Maximum = 100;
            trackBar_quality.Name = "trackBar_quality";
            trackBar_quality.Size = new Size(405, 45);
            trackBar_quality.TabIndex = 2;
            trackBar_quality.TickFrequency = 10;
            trackBar_quality.TickStyle = TickStyle.TopLeft;
            trackBar_quality.Value = 100;
            trackBar_quality.Scroll += trackBar_quality_Scroll;
            // 
            // tab_log
            // 
            tab_log.Controls.Add(button_clearLog);
            tab_log.Controls.Add(textBox_log);
            tab_log.Location = new Point(4, 24);
            tab_log.Name = "tab_log";
            tab_log.Size = new Size(417, 379);
            tab_log.TabIndex = 2;
            tab_log.Text = "Log";
            tab_log.UseVisualStyleBackColor = true;
            // 
            // button_clearLog
            // 
            button_clearLog.Location = new Point(369, 3);
            button_clearLog.Name = "button_clearLog";
            button_clearLog.Size = new Size(45, 23);
            button_clearLog.TabIndex = 1;
            button_clearLog.Text = "Clear";
            button_clearLog.UseVisualStyleBackColor = true;
            button_clearLog.Click += button_clearLog_Click;
            // 
            // textBox_log
            // 
            textBox_log.BackColor = Color.White;
            textBox_log.Location = new Point(3, 3);
            textBox_log.Name = "textBox_log";
            textBox_log.ReadOnly = true;
            textBox_log.Size = new Size(411, 373);
            textBox_log.TabIndex = 0;
            textBox_log.TabStop = false;
            textBox_log.Text = "";
            textBox_log.WordWrap = false;
            // 
            // button_convert
            // 
            button_convert.Enabled = false;
            button_convert.Location = new Point(12, 454);
            button_convert.Name = "button_convert";
            button_convert.Size = new Size(75, 23);
            button_convert.TabIndex = 10;
            button_convert.Text = "Convert";
            button_convert.UseVisualStyleBackColor = true;
            button_convert.Click += button_convert_Click;
            // 
            // progressBar_convert
            // 
            progressBar_convert.Location = new Point(12, 425);
            progressBar_convert.Name = "progressBar_convert";
            progressBar_convert.Size = new Size(423, 23);
            progressBar_convert.TabIndex = 1;
            // 
            // button_cancelConvert
            // 
            button_cancelConvert.Enabled = false;
            button_cancelConvert.Location = new Point(360, 454);
            button_cancelConvert.Name = "button_cancelConvert";
            button_cancelConvert.Size = new Size(75, 23);
            button_cancelConvert.TabIndex = 11;
            button_cancelConvert.Text = "Cancel";
            button_cancelConvert.UseVisualStyleBackColor = true;
            button_cancelConvert.Click += button_cancelConvert_Click;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 487);
            Controls.Add(button_cancelConvert);
            Controls.Add(progressBar_convert);
            Controls.Add(tabControl_main);
            Controls.Add(button_convert);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainWindow";
            Text = "WebPify";
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
