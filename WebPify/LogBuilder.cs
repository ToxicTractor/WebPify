namespace WebPify
{
    internal class LogBuilder
    {
        private RichTextBox _textBox;

        public LogBuilder(RichTextBox textBox)
        {
            _textBox = textBox;
        }

        public void Log(string text, Color? color = null, ELogVisibility logVisibility = ELogVisibility.User | ELogVisibility.Internal)
        {
            if (logVisibility.HasFlag(ELogVisibility.User))
            {
                if (color == null)
                    color = Color.Black;

                _textBox.SuspendLayout();
                _textBox.SelectionColor = color.Value;

                if (text == "")
                    _textBox.AppendText(Environment.NewLine);
                else
                {
                    // append text as rich text to allow for links
                    _textBox.SelectedRtf = @"{\rtf1\ansi " + text + @"\line}";
                }

                _textBox.ScrollToCaret();
                _textBox.ResumeLayout();
            }

            if (logVisibility.HasFlag(ELogVisibility.Internal))
            {
                // write to log file if the line is not empty
                if (!string.IsNullOrEmpty(text))
                    File.AppendAllText(Constants.LOG_FILE_PATH, $"[{DateTime.Now}] {text}{Environment.NewLine}");
            }
        }

        public void LogError(string text, ELogVisibility logVisibility = ELogVisibility.User | ELogVisibility.Internal)
        {
            if (string.IsNullOrEmpty(text))
                return;

            Log($"[ERROR] {text}", Color.Red, logVisibility);
        }

        public void LogEmptyLine(ELogVisibility logVisibility = ELogVisibility.User)
        {
            if (logVisibility.HasFlag(ELogVisibility.User))
            {
                _textBox.SuspendLayout();
                _textBox.AppendText(Environment.NewLine);
                _textBox.ScrollToCaret();
                _textBox.ResumeLayout();
            }

            if (logVisibility.HasFlag(ELogVisibility.Internal))
            {
                File.AppendAllText(Constants.LOG_FILE_PATH, Environment.NewLine);
            }
        }

        public static string FormatAsLink(string link, string? prettyName = null)
        {
            link = link.Replace("\\", "/"); // link formatting requires forward slashes

            if (prettyName == null)
                prettyName = link;
            else
                prettyName = prettyName.Replace("\\", "/");

            string res = @"{\field{\*\fldinst HYPERLINK """ + link + @"""}{\fldrslt {" + prettyName + "}}}";

            return res;
        }
    }
}
