using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("Notification", Schema = "GS1")]
    public class Notification : DbEntry
    {

        
        public string? CreationDateTime { get; set; }

        
        public string? DocumentStatusCode { get; set; }

        
        public string? EntityIdentification { get; set; }

        
        public string? Gln { get; set; }

        
        public string? IsReload { get; set; }

        public List<Item>? Items { get; set; }
    }
}
