using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("NotificationMessage", Schema = "GS1")]
    public class NotificationMessage : CatalogueMessage
    {

        
        public string? HeaderVersion { get; set; }

        
        public string? IdentifierAuthority { get; set; }

        
        public string? Identifier { get; set; }

        
        public string? Standard { get; set; }

        
        public string? TypeVersion { get; set; }

        
        public string? InstanceIdentifier { get; set; }

        
        public string? Type { get; set; }

        
        public string? CreationDateAndTime { get; set; }

        
        public string? EntityIdentification { get; set; }

        
        public string? Gln { get; set; }

        public List<Notification>? Notifications { get; set; }
    }

}
