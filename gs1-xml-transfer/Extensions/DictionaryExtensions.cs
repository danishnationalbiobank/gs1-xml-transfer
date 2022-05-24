using Newtonsoft.Json;

namespace Gs1XmlTransfer.Extensions
{
    public static class DictionaryExtensions
    {
        public static T ToObject<T>(this Dictionary<string, string> dictionary) where T : new()
        {
            var json = JsonConvert.SerializeObject(dictionary, Formatting.Indented);
            var objectResult = JsonConvert.DeserializeObject<T>(json);
            return objectResult ?? new T();
        }
    }
}
