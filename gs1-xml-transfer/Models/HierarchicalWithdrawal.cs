using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("HierarchicalWithdrawal", Schema = "GS1")]
    public class HierarchicalWithdrawal : DbEntry
    {
        
        public string? CreationDateTime { get; set; }

        
        public string? DocumentStatusCode { get; set; }

        
        public string? EntityIdentification { get; set; }

        
        public string? Gln { get; set; }

        
        public string? CatalogueItemStateCode { get; set; }

        
        public string? HierarchyDeletionReasonCode { get; set; }

        
        public string? DataSource { get; set; }

        
        public string? Gtin { get; set; }

        
        public string? TargetMarketCountryCode { get; set; }
    }
}
