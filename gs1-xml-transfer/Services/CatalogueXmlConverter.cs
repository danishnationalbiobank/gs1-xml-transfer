using Gs1XmlTransfer.Extensions;
using Gs1XmlTransfer.Interfaces;
using Gs1XmlTransfer.Models;
using System.Xml.Linq;

namespace Gs1XmlTransfer.Services
{
    public class CatalogueXmlConverter : ICatalogueXmlConverter
    {
        private readonly List<string> REDUNDANT_NESTED_ELEMENTS = new List<string> { "catalogueItem", "catalogueItemChildItemLink", "childTradeItem", "referencedTradeItem" };

        public NotificationMessage? ConvertNotificationMessage(XElement xml, string fileName)
        {
            var notificationMessage = NotificationMessage(xml);
            var notifications = Notifications(xml);

            if (notificationMessage is not null)
            {
                notificationMessage.FileName = fileName;
                notificationMessage.Notifications = notifications;
            }
            return notificationMessage;
        }

        public WithdrawalMessage? ConvertWithdrawalMessage(XElement xmlContent, string fileName)
        {
            var withDrawalMessageXml = new XElement(xmlContent).RemoveAllNamespaces();
            var hierarchicalWithdrawalXml = withDrawalMessageXml.Descendants("catalogueItemHierarchicalWithdrawal").ToList();
            var hierarchicalWithdrawals = new List<HierarchicalWithdrawal>();

            hierarchicalWithdrawalXml.ForEach(hwXml =>
            {
                var hierarchicalWithdrawal = hwXml.ToFlatDictionary().ToObject<HierarchicalWithdrawal>();
                hierarchicalWithdrawals.Add(hierarchicalWithdrawal);
            });

            withDrawalMessageXml.Descendants("catalogueItemHierarchicalWithdrawal").Remove();
            var withDrawalMessage = withDrawalMessageXml.ToFlatDictionary().ToObject<WithdrawalMessage>();
            withDrawalMessage.FileName = fileName;          
            withDrawalMessage.HierarchicalWithdrawals = hierarchicalWithdrawals;
            return withDrawalMessage;
        }

        private NotificationMessage? NotificationMessage(XElement xmlContent)
        {
            var messageXmlCopy = new XElement(xmlContent).RemoveAllNamespaces();
            messageXmlCopy.Descendants("catalogueItemNotification").Remove();
            var message = messageXmlCopy.ToFlatDictionary().ToObject<NotificationMessage>();
            return message;
        }

        private List<Notification>? Notifications(XElement xmlContent)
        {
            var notificationsXmlCopy = new XElement(xmlContent).RemoveAllNamespaces();
            var notificationElements = notificationsXmlCopy.Descendants("catalogueItemNotification").ToList();

            var notifications = new List<Notification>();

            notificationElements.ForEach(notificationElement =>
            {
                var notification = Notification(notificationElement);
                var items = Items(notificationElement);

                if (notification is not  null)
                {
                    notification.Items = items;
                    notifications.Add(notification);
                }
            });

            return notifications;
        }

        private List<Item>? Items(XElement notificationElement)
        {
            var catalogueItemXmlXopy = new XElement(notificationElement);
            var itemElements = catalogueItemXmlXopy.Descendants("catalogueItem").ToList();

            var items = new List<Item>();

            itemElements.ForEach(itemElement =>
            {
                itemElement.RemoveDescendants(REDUNDANT_NESTED_ELEMENTS);
                var item = itemElement.ToFlatDictionary().ToObject<Item>();

                var nutrientsXml = itemElement.Descendants("nutrientHeader").ToList();
                var nutrientDetails = NutrientDetails(nutrientsXml);
                item.NutrientDetails = nutrientDetails;

                items.Add(item);
            });

            return items;
        }

        private Notification? Notification(XElement notificationElement)
        {
            var notificationXmlCopy = new XElement(notificationElement);
            notificationXmlCopy.RemoveDescendants(REDUNDANT_NESTED_ELEMENTS);
            var notification = notificationXmlCopy.ToFlatDictionary().ToObject<Notification>();
            return notification;
        }

        private List<NutrientDetail>? NutrientDetails(List<XElement> nutrientsElement)
        {
            var nutrientDetails = new List<NutrientDetail>();

            nutrientsElement.Descendants("nutrientDetail").ToList().ForEach(nutrientDetailsElem =>
            {
                var nutriTypeCodeElem = nutrientDetailsElem.Descendants("nutrientTypeCode").FirstOrDefault();
                var measPrecCodeElem = nutrientDetailsElem.Descendants("measurementPrecisionCode").FirstOrDefault();
                var quantContElem = nutrientDetailsElem.Descendants("quantityContained");

                // If there are multiple measurement unit codes, we create a separate nutrient detail record for each of them
                quantContElem.ToList().ForEach(q =>
                {
                    var nutrientDetail = new NutrientDetail();
                    nutrientDetail.NutrientTypeCode = nutriTypeCodeElem?.Value;
                    nutrientDetail.MeasurementPrecisionCode = measPrecCodeElem?.Value;
                    nutrientDetail.MeasurementUnitCode = q?.Attribute("measurementUnitCode")?.Value;
                    nutrientDetail.QuantityContained = q?.Value;
                    nutrientDetails.Add(nutrientDetail);
                });

            });

            return nutrientDetails;
        }
    }
}
