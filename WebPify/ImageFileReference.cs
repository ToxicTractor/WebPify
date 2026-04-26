namespace WebPify
{
    public struct ImageFileReference
    {
        public string FilePath;
        public string FileName;
        public string FullFileName;
        public string Extension;
        public string DirectoryPath;
        public string FilePathNoExtension;

        public ImageFileReference(string filePath)
        {
            FilePath = filePath;
            FileName = Path.GetFileNameWithoutExtension(FilePath) ?? string.Empty;
            FullFileName = Path.GetFileName(FilePath) ?? string.Empty;
            Extension = Path.GetExtension(FilePath) ?? string.Empty;
            DirectoryPath = Path.GetDirectoryName(FilePath) ?? string.Empty;
            FilePathNoExtension = Path.Combine(DirectoryPath, FileName);
        }
    }
}
