using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("NutrientDetail", Schema = "GS1")]
    public class NutrientDetail : DbEntry
    {
        
        public string? NutrientTypeCode { get; set; }

        
        public string? MeasurementPrecisionCode { get; set; }

        
        public string? MeasurementUnitCode { get; set; }

        
        public string? QuantityContained { get; set; }
    }
}
