using Gs1XmlTransfer.Interfaces;

namespace Gs1XmlTransfer.Configuration
{
    public class AppConfiguration : IAppConfiguration
    {
        public ConnectionStrings? ConnectionStrings { get; set; }
        public FtpConfiguration? Ftp { get; set; }
        public bool UseLocalFiles { get; set; }
        public string? LocalFilesDirectory { get; set; }

    }
    public class ConnectionStrings
    {
        public string? Gs1Catalogue { get; set; }
    }

    public class FtpConfiguration
    {
        public string? Host { get; set; }
        public string? Directory { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
}
