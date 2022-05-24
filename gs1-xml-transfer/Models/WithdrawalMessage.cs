using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("WithdrawalMessage", Schema = "GS1")]
    public class WithdrawalMessage : CatalogueMessage
    {
        
        public string? HeaderVersion { get; set; }

        
        public string? Identifier { get; set; }

        
        public string? Standard { get; set; }

        
        public string? TypeVersion { get; set; }

        
        public string? InstanceIdentifier { get; set; }

        
        public string? Type { get; set; }

        
        public string? CreationDateAndTime { get; set; }

        public List<HierarchicalWithdrawal>? HierarchicalWithdrawals { get; set; }
    }
}

