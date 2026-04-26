using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebPify
{
    public static class Utility
    {
        public static void OpenFolderBrowser(MainWindow mainWindow, Action<string> onComplete)
        {
            var dialogue = new FolderBrowserDialog();

            var result = dialogue.ShowDialog();

            if (result == DialogResult.OK)
            {
                onComplete?.Invoke(dialogue.SelectedPath);
            }
        }

        public static void OpenFileBrowser(MainWindow mainWindow, Action<string> onComplete)
        {
            var dialogue = new OpenFileDialog();

            string filter = "Images files (";

            bool isFirst = true;
            for (int i = 0; i < Constants.SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = Constants.SUPPORTED_FILE_FORMATS[i];

                if (!mainWindow.IsFormatEnabled(format))
                    continue;

                if (isFirst)
                    isFirst = false;
                else
                    filter += ", ";

                filter += $"{format.Name}";
            }
            isFirst = true;
            filter += ")|";
            for (int i = 0; i < Constants.SUPPORTED_FILE_FORMATS.Length; i++)
            {
                var format = Constants.SUPPORTED_FILE_FORMATS[i];

                if (!mainWindow.IsFormatEnabled(format))
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
    }
}
