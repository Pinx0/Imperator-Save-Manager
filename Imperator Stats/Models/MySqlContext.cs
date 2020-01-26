using System.ComponentModel.DataAnnotations.Schema;
using ImperatorSaveParser;
using Microsoft.EntityFrameworkCore;

namespace ImperatorStats.Models
{
    public class MySqlContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Save> Saves { get; set; }

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<CountryManager>();
            modelBuilder.Ignore<FamilyManager>();
            modelBuilder.Ignore<CountryTechnologies>();
            modelBuilder.Entity<Save>().HasKey(c => c.SaveId).HasAnnotation("DatabaseGenerated",DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Save>().HasMany(c => c.Families).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Save>().HasMany(c => c.Countries).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Country>().HasOne(c => c.Save);
            modelBuilder.Entity<Country>().HasOne(c => c.CurrencyData).WithOne(x => x.Country).HasForeignKey<CountryCurrencyData>(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasMany(c => c.Technologies).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasMany(c => c.Players).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasOne(c => c.Economy).WithOne(x => x.Country).HasForeignKey<CountryEconomy>(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasKey(c => new { c.SaveId, c.CountryId });
            modelBuilder.Entity<Country>().Ignore(c => c.PlayedBy);
            modelBuilder.Entity<Family>().HasKey(c => new { c.SaveId, c.FamilyId });
            modelBuilder.Entity<CountryCurrencyData>().HasKey(c => new { c.SaveId, c.CountryId });
            modelBuilder.Entity<CountryCurrencyData>().HasOne(c => c.Country);
            modelBuilder.Entity<CountryCurrencyData>().Property(c => c.SaveId).HasMaxLength(50);
            modelBuilder.Entity<CountryEconomy>().HasKey(c => new { c.SaveId, c.CountryId });
            modelBuilder.Entity<CountryEconomy>().HasMany(c => c.Telemetries).WithOne(x => x.CountryEconomy).HasForeignKey(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<CountryEconomy>().HasOne(c => c.Country);
            modelBuilder.Entity<CountryEconomyTelemetry>().HasKey(c => new { c.SaveId, c.CountryId,  c.Type });
            modelBuilder.Entity<CountryEconomyTelemetry>().HasOne(c => c.CountryEconomy);
            modelBuilder.Entity<CountryPlayer>().HasKey(c => new { c.SaveId, c.CountryId, c.PlayerName });
            modelBuilder.Entity<CountryPlayer>().HasOne(c => c.Country);
            modelBuilder.Entity<CountryPlayer>().Property(c => c.PlayerName).HasMaxLength(100);
            modelBuilder.Entity<CountryTechnology>().HasKey(c => new { c.SaveId, c.CountryId, c.Type });
            modelBuilder.Entity<CountryTechnology>().HasOne(c => c.Country);
        }

    }
}
