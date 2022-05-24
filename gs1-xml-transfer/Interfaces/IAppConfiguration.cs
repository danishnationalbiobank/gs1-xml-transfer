using Gs1XmlTransfer.Configuration;

namespace Gs1XmlTransfer.Interfaces
{
    public interface IAppConfiguration
    {
        ConnectionStrings? ConnectionStrings { get; set; }
        FtpConfiguration? Ftp { get; set; }
        string? LocalFilesDirectory { get; set; }
        bool UseLocalFiles { get; set; }
    }
}