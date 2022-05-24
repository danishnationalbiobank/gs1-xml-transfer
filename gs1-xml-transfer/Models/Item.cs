using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gs1XmlTransfer.Models
{
    [Table("Item", Schema = "GS1")]
    public class Item : DbEntry
    {
        
        public string? DataRecipient { get; set; }

        
        public string? CatalogueItemStateCode { get; set; }

        
        public string? Gtin { get; set; }

        
        public string? AdditionalTradeItemIdentificationAdditionalTradeItemIdentificationTypeCode { get; set; }

        
        public string? AdditionalTradeItemIdentification { get; set; }

        
        public string? IsTradeItemABaseUnit { get; set; }

        
        public string? IsTradeItemAConsumerUnit { get; set; }

        
        public string? IsTradeItemADespatchUnit { get; set; }

        
        public string? IsTradeItemAnInvoiceUnit { get; set; }

        
        public string? IsTradeItemAnOrderableUnit { get; set; }

        
        public string? TradeItemUnitDescriptorCode { get; set; }

        
        public string? Gln { get; set; }

        
        public string? PartyName { get; set; }

        
        public string? GpcCategoryCode { get; set; }

        
        public string? TargetMarketCountryCode { get; set; }

        
        public string? ContactTypeCode { get; set; }

        
        public string? CommunicationChannelCode { get; set; }

        
        public string? CommunicationValue { get; set; }

        
        public string? AllergenSpecificationAgency { get; set; }

        
        public string? AllergenSpecificationName { get; set; }

        
        public string? AllergenTypeCode { get; set; }

        
        public string? LevelOfContainmentCode { get; set; }

        
        public string? IsHomogenised { get; set; }

        
        public string? IsDangerousSubstance { get; set; }

        
        public string? StartAvailabilityDateTime { get; set; }

        
        public string? DutyFeeTaxAgencyCode { get; set; }

        
        public string? DutyFeeTaxTypeCode { get; set; }

        
        public string? OrganicTradeItemCode { get; set; }

        
        public string? IngredientStatementLanguageCode { get; set; }


        public string? IngredientStatement { get; set; }

        
        public string? TradeItemMarketingMessageLanguageCode { get; set; }

        
        public string? TradeItemMarketingMessage { get; set; }

        
        public string? PreparationStateCode { get; set; }

        
        public string? ServingSizeMeasurementUnitCode { get; set; }

        
        public string? ServingSize { get; set; }

        
        public string? NutrientTypeCode { get; set; }

        
        public string? MeasurementPrecisionCode { get; set; }

        
        public string? QuantityContainedMeasurementUnitCode { get; set; }

        
        public string? QuantityContained { get; set; }

        
        public string? PackagingTypeCode { get; set; }

        
        public string? IsPackagingMarkedReturnable { get; set; }

        
        public string? IsPriceOnPack { get; set; }

        
        public string? TradeItemDateOnPackagingTypeCode { get; set; }

        
        public string? ImportClassificationTypeCode { get; set; }

        
        public string? ImportClassificationValue { get; set; }

        
        public string? CountryCode { get; set; }

        
        public string? SDSSheetNumber { get; set; }

        
        public string? IsRegulatedForTransportation { get; set; }

        
        public string? IsBasePriceDeclarationRelevant { get; set; }

        
        public string? DoesTradeItemContainPesticide { get; set; }

        
        public string? DataCarrierTypeCode { get; set; }

        
        public string? DescriptionShortLanguageCode { get; set; }

        
        public string? DescriptionShort { get; set; }

        
        public string? FunctionalNameLanguageCode { get; set; }

        
        public string? FunctionalName { get; set; }

        
        public string? BrandName { get; set; }

        
        public string? MinimumTradeItemLifespanFromTimeOfArrival { get; set; }

        
        public string? MinimumTradeItemLifespanFromTimeOfProduction { get; set; }

        
        public string? OpenedTradeItemLifespan { get; set; }

        
        public string? DepthMeasurementUnitCode { get; set; }

        
        public string? Depth { get; set; }

        
        public string? HeightMeasurementUnitCode { get; set; }

        
        public string? Height { get; set; }

        
        public string? NetContentMeasurementUnitCode { get; set; }

        
        public string? NetContent { get; set; }

        
        public string? WidthMeasurementUnitCode { get; set; }

        
        public string? Width { get; set; }

        
        public string? GrossWeightMeasurementUnitCode { get; set; }

        
        public string? GrossWeight { get; set; }

        
        public string? NetWeightMeasurementUnitCode { get; set; }

        
        public string? NetWeight { get; set; }

        
        public string? IsTradeItemAVariableUnit { get; set; }

        
        public string? LastChangeDateTime { get; set; }

        
        public string? EffectiveDateTime { get; set; }

        
        public string? PublicationDateTime { get; set; }

        public List<NutrientDetail>? NutrientDetails { get; set; }
    }

}
