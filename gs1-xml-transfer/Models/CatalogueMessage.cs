using System.ComponentModel.DataAnnotations;

namespace Gs1XmlTransfer.Models
{
    public class CatalogueMessage : DbEntry
    {
        [Required]
        [StringLength(255)]
        public string? FileName { get; set; }

        public DateTime RTimestamp { get; set; } = DateTime.Now;
    }
}
