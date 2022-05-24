using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gs1XmlTransfer.Exceptions
{
    public class CatalogueFileNameException : Exception
    {
        public CatalogueFileNameException(string message)
       : base(message)
        {
        }

    }
}
