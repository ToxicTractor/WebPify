namespace WebPify
{
    public static class Constants
    {
        public const string LOG_FILE_PATH = @"webpify.log";

        public static readonly ImageFormat FORMAT_PNG = new()
        {
            Name = "PNG",
            Extension = ".png"
        };

        public static readonly ImageFormat FORMAT_JPG = new()
        {
            Name = "JPG/JPEG",
            Extension = ".jpg",
            AlternateExtension = ".jpeg"
        };

        public static readonly ImageFormat FORMAT_TIFF = new()
        {
            Name = "TIFF",
            Extension = ".tiff"
        };

        public static readonly ImageFormat[] SUPPORTED_FILE_FORMATS = [
            FORMAT_JPG,
            FORMAT_PNG,
            FORMAT_TIFF,
            ];
    }
}
