using Gs1XmlTransfer.Configuration;
using Gs1XmlTransfer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Gs1XmlTransfer.Persistence
{
    public class Gs1CatalogueContext : DbContext
    {
        private readonly string _connectionString = AppConfigurationBuilder.Get().GetConnectionString("Gs1Catalogue");

        public DbSet<NotificationMessage>? NotificationMessage { get; set; }

        public DbSet<Notification>? Notification { get; set; }

        public DbSet<Item>? Item { get; set; }

        public DbSet<NutrientDetail>? NutrientDetail { get; set; }

        public DbSet<WithdrawalMessage>? WithdrawalMessage { get; set; }

        public DbSet<HierarchicalWithdrawal>? HierarchicalWithdrawal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(_connectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NotificationMessage>()
                .Property(b => b.RTimestamp)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<WithdrawalMessage>()
                .Property(b => b.RTimestamp)
                .HasColumnType("datetime")
                .HasDefaultValueSql("getdate()");

            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties())
                .Where(p => p.ClrType == typeof(string) && p.Name != "IngredientStatement")) 
                {
                    property.SetColumnType("varchar(8000)");
                }
            }
    }
}
