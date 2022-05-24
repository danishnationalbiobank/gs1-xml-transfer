using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Gs1XmlTransfer.Interfaces
{
    public interface IXmlFileReader
    {
        List<string> ReadFileNames();

        XElement ReadXml(string fileName);
    }
}
