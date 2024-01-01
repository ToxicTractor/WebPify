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
            tabControl_main = new TabControl();
            tab_main = new TabPage();
            checkBox_replaceOriginals = new CheckBox();
            checkBox_scanSubdirectories = new CheckBox();
            checkBox_batchConvert = new CheckBox();
            label_imagesFound = new Label();
            button_convert = new Button();
            label_output = new Label();
            textBox_output = new TextBox();
            button_browse_output = new Button();
            textBox_source = new TextBox();
            label_source = new Label();
            button_browse_source = new Button();
            tab_settings = new TabPage();
            label_quality = new Label();
            label_compression = new Label();
            textBox_defaultOutputFolderName = new TextBox();
            label_outputFolderName = new Label();
            comboBox_compression = new ComboBox();
            label_qualityValue = new Label();
            trackBar_quality = new TrackBar();
            tab_log = new TabPage();
            textBox_log = new RichTextBox();
            progressBar_convert = new ProgressBar();
            tabControl_main.SuspendLayout();
            tab_main.SuspendLayout();
            tab_settings.SuspendLayout();
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
            tabControl_main.Size = new Size(425, 299);
            tabControl_main.TabIndex = 0;
            // 
            // tab_main
            // 
            tab_main.Controls.Add(checkBox_replaceOriginals);
            tab_main.Controls.Add(checkBox_scanSubdirectories);
            tab_main.Controls.Add(checkBox_batchConvert);
            tab_main.Controls.Add(label_imagesFound);
            tab_main.Controls.Add(button_convert);
            tab_main.Controls.Add(label_output);
            tab_main.Controls.Add(textBox_output);
            tab_main.Controls.Add(button_browse_output);
            tab_main.Controls.Add(textBox_source);
            tab_main.Controls.Add(label_source);
            tab_main.Controls.Add(button_browse_source);
            tab_main.Location = new Point(4, 24);
            tab_main.Name = "tab_main";
            tab_main.Padding = new Padding(3);
            tab_main.Size = new Size(417, 271);
            tab_main.TabIndex = 0;
            tab_main.Text = "Main";
            tab_main.UseVisualStyleBackColor = true;
            // 
            // checkBox_replaceOriginals
            // 
            checkBox_replaceOriginals.AutoSize = true;
            checkBox_replaceOriginals.Location = new Point(12, 153);
            checkBox_replaceOriginals.Name = "checkBox_replaceOriginals";
            checkBox_replaceOriginals.Size = new Size(115, 19);
            checkBox_replaceOriginals.TabIndex = 15;
            checkBox_replaceOriginals.Text = "Replace originals";
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
            checkBox_scanSubdirectories.UseVisualStyleBackColor = true;
            checkBox_scanSubdirectories.CheckedChanged += checkBox_scanSubdirectories_CheckedChanged;
            // 
            // checkBox_batchConvert
            // 
            checkBox_batchConvert.AutoSize = true;
            checkBox_batchConvert.Location = new Point(12, 50);
            checkBox_batchConvert.Name = "checkBox_batchConvert";
            checkBox_batchConvert.Size = new Size(99, 19);
            checkBox_batchConvert.TabIndex = 13;
            checkBox_batchConvert.Text = "Batch convert";
            checkBox_batchConvert.UseVisualStyleBackColor = true;
            checkBox_batchConvert.CheckedChanged += checkBox_batchConvert_CheckedChanged;
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
            // button_convert
            // 
            button_convert.Enabled = false;
            button_convert.Location = new Point(170, 242);
            button_convert.Name = "button_convert";
            button_convert.Size = new Size(75, 23);
            button_convert.TabIndex = 10;
            button_convert.Text = "Convert";
            button_convert.UseVisualStyleBackColor = true;
            button_convert.Click += button_convert_Click;
            // 
            // label_output
            // 
            label_output.AutoSize = true;
            label_output.Location = new Point(6, 106);
            label_output.Name = "label_output";
            label_output.Size = new Size(75, 15);
            label_output.TabIndex = 5;
            label_output.Text = "Output path:";
            // 
            // textBox_output
            // 
            textBox_output.Location = new Point(6, 124);
            textBox_output.Name = "textBox_output";
            textBox_output.ReadOnly = true;
            textBox_output.Size = new Size(324, 23);
            textBox_output.TabIndex = 4;
            textBox_output.TextChanged += textBox_output_TextChanged;
            // 
            // button_browse_output
            // 
            button_browse_output.Location = new Point(336, 124);
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
            textBox_source.TextChanged += textBox_source_TextChanged;
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
            tab_settings.Controls.Add(label_quality);
            tab_settings.Controls.Add(label_compression);
            tab_settings.Controls.Add(textBox_defaultOutputFolderName);
            tab_settings.Controls.Add(label_outputFolderName);
            tab_settings.Controls.Add(comboBox_compression);
            tab_settings.Controls.Add(label_qualityValue);
            tab_settings.Controls.Add(trackBar_quality);
            tab_settings.Location = new Point(4, 24);
            tab_settings.Name = "tab_settings";
            tab_settings.Padding = new Padding(3);
            tab_settings.Size = new Size(417, 271);
            tab_settings.TabIndex = 1;
            tab_settings.Text = "Settings";
            tab_settings.UseVisualStyleBackColor = true;
            // 
            // label_quality
            // 
            label_quality.AutoSize = true;
            label_quality.Location = new Point(6, 142);
            label_quality.Name = "label_quality";
            label_quality.Size = new Size(51, 15);
            label_quality.TabIndex = 8;
            label_quality.Text = "Quality: ";
            // 
            // label_compression
            // 
            label_compression.AutoSize = true;
            label_compression.Location = new Point(6, 75);
            label_compression.Name = "label_compression";
            label_compression.Size = new Size(103, 15);
            label_compression.TabIndex = 7;
            label_compression.Text = "Compression type";
            // 
            // textBox_defaultOutputFolderName
            // 
            textBox_defaultOutputFolderName.Location = new Point(6, 21);
            textBox_defaultOutputFolderName.Name = "textBox_defaultOutputFolderName";
            textBox_defaultOutputFolderName.Size = new Size(176, 23);
            textBox_defaultOutputFolderName.TabIndex = 0;
            textBox_defaultOutputFolderName.Text = "_output";
            // 
            // label_outputFolderName
            // 
            label_outputFolderName.AutoSize = true;
            label_outputFolderName.Location = new Point(6, 3);
            label_outputFolderName.Name = "label_outputFolderName";
            label_outputFolderName.Size = new Size(154, 15);
            label_outputFolderName.TabIndex = 5;
            label_outputFolderName.Text = "Default output folder name:";
            // 
            // comboBox_compression
            // 
            comboBox_compression.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_compression.FormattingEnabled = true;
            comboBox_compression.Items.AddRange(new object[] { "Lossy", "Lossless" });
            comboBox_compression.Location = new Point(6, 93);
            comboBox_compression.Name = "comboBox_compression";
            comboBox_compression.Size = new Size(121, 23);
            comboBox_compression.TabIndex = 4;
            // 
            // label_qualityValue
            // 
            label_qualityValue.AutoSize = true;
            label_qualityValue.Location = new Point(199, 190);
            label_qualityValue.Name = "label_qualityValue";
            label_qualityValue.Size = new Size(19, 15);
            label_qualityValue.TabIndex = 3;
            label_qualityValue.Text = "90";
            // 
            // trackBar_quality
            // 
            trackBar_quality.BackColor = Color.White;
            trackBar_quality.Location = new Point(6, 160);
            trackBar_quality.Maximum = 100;
            trackBar_quality.Name = "trackBar_quality";
            trackBar_quality.Size = new Size(405, 45);
            trackBar_quality.TabIndex = 2;
            trackBar_quality.TickFrequency = 10;
            trackBar_quality.TickStyle = TickStyle.TopLeft;
            trackBar_quality.Value = 90;
            trackBar_quality.Scroll += trackBar_quality_Scroll;
            // 
            // tab_log
            // 
            tab_log.Controls.Add(textBox_log);
            tab_log.Location = new Point(4, 24);
            tab_log.Name = "tab_log";
            tab_log.Size = new Size(417, 271);
            tab_log.TabIndex = 2;
            tab_log.Text = "Log";
            tab_log.UseVisualStyleBackColor = true;
            // 
            // textBox_log
            // 
            textBox_log.BackColor = Color.White;
            textBox_log.Location = new Point(3, 3);
            textBox_log.Name = "textBox_log";
            textBox_log.ReadOnly = true;
            textBox_log.Size = new Size(411, 265);
            textBox_log.TabIndex = 0;
            textBox_log.Text = "";
            textBox_log.WordWrap = false;
            // 
            // progressBar_convert
            // 
            progressBar_convert.Location = new Point(12, 317);
            progressBar_convert.Name = "progressBar_convert";
            progressBar_convert.Size = new Size(423, 23);
            progressBar_convert.TabIndex = 1;
            // 
            // MainWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(447, 349);
            Controls.Add(progressBar_convert);
            Controls.Add(tabControl_main);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "MainWindow";
            Text = "WebPify";
            Load += MainWindow_Load;
            tabControl_main.ResumeLayout(false);
            tab_main.ResumeLayout(false);
            tab_main.PerformLayout();
            tab_settings.ResumeLayout(false);
            tab_settings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar_quality).EndInit();
            tab_log.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl_main;
        private TabPage tab_main;
        private TabPage tab_settings;
        private Label label_source;
        private Button button_browse_source;
        private Label label_output;
        private TextBox textBox_output;
        private Button button_browse_output;
        private TextBox textBox_source;
        private Button button_convert;
        private Label label_imagesFound;
        private TabPage tab_log;
        private RichTextBox textBox_log;
        private CheckBox checkBox_batchConvert;
        private CheckBox checkBox_scanSubdirectories;
        private CheckBox checkBox_replaceOriginals;
        private TextBox textBox_defaultOutputFolderName;
        private ProgressBar progressBar_convert;
        private TrackBar trackBar_quality;
        private ComboBox comboBox_compression;
        private Label label_qualityValue;
        private Label label_outputFolderName;
        private Label label_quality;
        private Label label_compression;
    }
}
