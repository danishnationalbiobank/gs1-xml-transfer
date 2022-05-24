using Gs1XmlTransfer.Models;
using System.Xml.Linq;

namespace Gs1XmlTransfer.Interfaces
{
    public interface ICatalogueXmlConverter
    {
        NotificationMessage? ConvertNotificationMessage(XElement xml, string fileName);
        WithdrawalMessage? ConvertWithdrawalMessage(XElement xmlContent, string fileName);
    }
}