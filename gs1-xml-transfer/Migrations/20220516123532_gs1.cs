using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Gs1XmlTransfer.Migrations
{
    public partial class gs1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "GS1");

            migrationBuilder.CreateTable(
                name: "NotificationMessage",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderVersion = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IdentifierAuthority = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Identifier = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Standard = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TypeVersion = table.Column<string>(type: "varchar(8000)", nullable: true),
                    InstanceIdentifier = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Type = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CreationDateAndTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    EntityIdentification = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gln = table.Column<string>(type: "varchar(8000)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    RTimestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WithdrawalMessage",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeaderVersion = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Identifier = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Standard = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TypeVersion = table.Column<string>(type: "varchar(8000)", nullable: true),
                    InstanceIdentifier = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Type = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CreationDateAndTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    FileName = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    RTimestamp = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WithdrawalMessage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DocumentStatusCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    EntityIdentification = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gln = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsReload = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NotificationMessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationMessage_NotificationMessageId",
                        column: x => x.NotificationMessageId,
                        principalSchema: "GS1",
                        principalTable: "NotificationMessage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HierarchicalWithdrawal",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DocumentStatusCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    EntityIdentification = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gln = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CatalogueItemStateCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    HierarchyDeletionReasonCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DataSource = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gtin = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TargetMarketCountryCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    WithdrawalMessageId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HierarchicalWithdrawal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HierarchicalWithdrawal_WithdrawalMessage_WithdrawalMessageId",
                        column: x => x.WithdrawalMessageId,
                        principalSchema: "GS1",
                        principalTable: "WithdrawalMessage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Item",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRecipient = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CatalogueItemStateCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gtin = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AdditionalTradeItemIdentificationAdditionalTradeItemIdentificationTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AdditionalTradeItemIdentification = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemABaseUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemAConsumerUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemADespatchUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemAnInvoiceUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemAnOrderableUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TradeItemUnitDescriptorCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Gln = table.Column<string>(type: "varchar(8000)", nullable: true),
                    PartyName = table.Column<string>(type: "varchar(8000)", nullable: true),
                    GpcCategoryCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TargetMarketCountryCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ContactTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CommunicationChannelCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CommunicationValue = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AllergenSpecificationAgency = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AllergenSpecificationName = table.Column<string>(type: "varchar(8000)", nullable: true),
                    AllergenTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    LevelOfContainmentCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsHomogenised = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsDangerousSubstance = table.Column<string>(type: "varchar(8000)", nullable: true),
                    StartAvailabilityDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DutyFeeTaxAgencyCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DutyFeeTaxTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    OrganicTradeItemCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IngredientStatementLanguageCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IngredientStatement = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TradeItemMarketingMessageLanguageCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TradeItemMarketingMessage = table.Column<string>(type: "varchar(8000)", nullable: true),
                    PreparationStateCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ServingSizeMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ServingSize = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NutrientTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    MeasurementPrecisionCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    QuantityContainedMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    QuantityContained = table.Column<string>(type: "varchar(8000)", nullable: true),
                    PackagingTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsPackagingMarkedReturnable = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsPriceOnPack = table.Column<string>(type: "varchar(8000)", nullable: true),
                    TradeItemDateOnPackagingTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ImportClassificationTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ImportClassificationValue = table.Column<string>(type: "varchar(8000)", nullable: true),
                    CountryCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    SDSSheetNumber = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsRegulatedForTransportation = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsBasePriceDeclarationRelevant = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DoesTradeItemContainPesticide = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DataCarrierTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DescriptionShortLanguageCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DescriptionShort = table.Column<string>(type: "varchar(8000)", nullable: true),
                    FunctionalNameLanguageCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    FunctionalName = table.Column<string>(type: "varchar(8000)", nullable: true),
                    BrandName = table.Column<string>(type: "varchar(8000)", nullable: true),
                    MinimumTradeItemLifespanFromTimeOfArrival = table.Column<string>(type: "varchar(8000)", nullable: true),
                    MinimumTradeItemLifespanFromTimeOfProduction = table.Column<string>(type: "varchar(8000)", nullable: true),
                    OpenedTradeItemLifespan = table.Column<string>(type: "varchar(8000)", nullable: true),
                    DepthMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Depth = table.Column<string>(type: "varchar(8000)", nullable: true),
                    HeightMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Height = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NetContentMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NetContent = table.Column<string>(type: "varchar(8000)", nullable: true),
                    WidthMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    Width = table.Column<string>(type: "varchar(8000)", nullable: true),
                    GrossWeightMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    GrossWeight = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NetWeightMeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NetWeight = table.Column<string>(type: "varchar(8000)", nullable: true),
                    IsTradeItemAVariableUnit = table.Column<string>(type: "varchar(8000)", nullable: true),
                    LastChangeDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    EffectiveDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    PublicationDateTime = table.Column<string>(type: "varchar(8000)", nullable: true),
                    NotificationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalSchema: "GS1",
                        principalTable: "Notification",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "NutrientDetail",
                schema: "GS1",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NutrientTypeCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    MeasurementPrecisionCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    MeasurementUnitCode = table.Column<string>(type: "varchar(8000)", nullable: true),
                    QuantityContained = table.Column<string>(type: "varchar(8000)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutrientDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutrientDetail_Item_ItemId",
                        column: x => x.ItemId,
                        principalSchema: "GS1",
                        principalTable: "Item",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HierarchicalWithdrawal_WithdrawalMessageId",
                schema: "GS1",
                table: "HierarchicalWithdrawal",
                column: "WithdrawalMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_NotificationId",
                schema: "GS1",
                table: "Item",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_NotificationMessageId",
                schema: "GS1",
                table: "Notification",
                column: "NotificationMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_NutrientDetail_ItemId",
                schema: "GS1",
                table: "NutrientDetail",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HierarchicalWithdrawal",
                schema: "GS1");

            migrationBuilder.DropTable(
                name: "NutrientDetail",
                schema: "GS1");

            migrationBuilder.DropTable(
                name: "WithdrawalMessage",
                schema: "GS1");

            migrationBuilder.DropTable(
                name: "Item",
                schema: "GS1");

            migrationBuilder.DropTable(
                name: "Notification",
                schema: "GS1");

            migrationBuilder.DropTable(
                name: "NotificationMessage",
                schema: "GS1");
        }
    }
}
