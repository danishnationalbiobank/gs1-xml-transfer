using FluentFTP;
using Gs1XmlTransfer.Interfaces;
using System.Text;
using System.Xml.Linq;

namespace Gs1XmlTransfer.Services
{
    public class FtpFileReader : IXmlFileReader
    {
        private readonly string _directory;
        private readonly FtpClient _client;

        public FtpFileReader(string host, string directory, string userName, string password)
        {
            _directory = directory;
            _client = new FtpClient(host, userName, password);
        }

        public List<string> ReadFileNames()
        {           
            _client.Connect();

            var fileNames = new List<string>();

            foreach (FtpListItem item in _client.GetListing($"/{_directory}"))
            {
                if (item.Type is FtpFileSystemObjectType.File)
                {
                    fileNames.Add(item.Name);
                }
            }

            _client.Disconnect();
            return fileNames;
        }

        public XElement ReadXml(string fileName)
        {
            string xmlContent = DownloadData($"{_directory}/{fileName}");
            return XElement.Parse(xmlContent);
        }

        private string DownloadData(string path)
        {
            _client.Connect();
            _client.Download(out byte[] bytes, path);
            var content = String.Empty;

            using (StreamReader reader = new StreamReader(new MemoryStream(bytes), true))
            {
                content = reader.ReadToEnd();
            }

            _client.Disconnect();
            return content;
        }
    }
}