using System.Xml.Linq;

namespace Gs1XmlTransfer.Extensions
{
    public static class XElementExtensions
    {
        public static XElement RemoveAllNamespaces(this XElement xElement)
        {
            if (!xElement.HasElements)
            {
                XElement xLocalName = new XElement(xElement.Name.LocalName);
                xLocalName.Value = xElement.Value;

                foreach (XAttribute attribute in xElement.Attributes())
                    xLocalName.Add(attribute);

                return xLocalName;
            }
            return new XElement(xElement.Name.LocalName, xElement.Elements().Select(el => RemoveAllNamespaces(el)));
        }

        public static Dictionary<string, string> ToFlatDictionary(this XElement xElement)
        {
            var dictionary = new Dictionary<string, string>();

            var descendants = xElement.Descendants();

            foreach (var descendant in descendants)
            {
                // If an element has children, it does not contain an actual value, so we skip to the next element/child
                if (descendant.HasElements)
                {
                    continue;
                }

                var elementName = descendant.Name.ToString().FirstCharToUpper();
                var elementValue = descendant.Value;
                var attributes = descendant.Attributes();

                if (attributes?.Count() > 0)
                {
                    attributes.ToList().ForEach(attribute =>
                    {
                        var actualAttributeName = attribute.Name.ToString();
                        var attNameUpper = char.ToUpper(actualAttributeName[0]) + actualAttributeName.Substring(1);
                        
                        var concatenatedAttributeName = elementName + attNameUpper;
                        var attributeValue = attribute.Value.ToString();

                        AddToDictionary(dictionary, concatenatedAttributeName, attributeValue);
                    });
                }

                AddToDictionary(dictionary, elementName, elementValue);
            }

            return dictionary;
        }

        public static void RemoveDescendants(this XElement xElement, List<string> elementsToRemove)
        {
            xElement.Descendants().ToList().ForEach(x =>
            {
                elementsToRemove.ForEach(e =>
                {
                    x.Descendants(e).Remove();
                });
            });
        }

        private static void AddToDictionary(Dictionary<string, string> dict, string name, string value)
        {
            var existingValue = dict.GetValueOrDefault(name);

            if (existingValue is null && value is not null)
            {
                dict.Add(name, value);
            }
            else
            {
                dict[name] = existingValue + ";" + value;
            }
        }
    }
}
