using Gs1XmlTransfer.Interfaces;
using System.Xml.Linq;

namespace Gs1XmlTransfer.Services
{
    public class LocalFileReader : IXmlFileReader
    {
        private readonly string _directory;

        public LocalFileReader(string directory)
        {
            _directory = directory;
        }

        public List<string> ReadFileNames()
        {
            string[] files = Directory.GetFiles(_directory);
            List<string> fileNames = new List<string>();
            
            foreach (string file in files)
            {
                fileNames.Add(Path.GetFileName(file));
            }

            return fileNames;
        }

        public XElement ReadXml(string fileName)
        {
            var filePath = $"{_directory}\\{fileName}";
            var content = File.ReadAllText(filePath);
            var xml = XElement.Parse(content);
            return xml;
        }
    }
}
