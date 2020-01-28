using System.ComponentModel.DataAnnotations.Schema;
using Imperator.Save;
using Microsoft.EntityFrameworkCore;

namespace ImperatorStats.Models
{
    public class ImperatorContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Save> Saves { get; set; }
        public DbSet<Family> Families { get; set; }
        public DbSet<Population> Pops { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<CountryPlayer> CountryPlayers { get; set; }
        public DbSet<CountryTechnology> CountryTechnologies { get; set; }

        public ImperatorContext(DbContextOptions<ImperatorContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Save>().HasKey(c => c.SaveId).HasAnnotation("DatabaseGenerated",DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Save>().HasMany(c => c.Families).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Save>().HasMany(c => c.Countries).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Save>().HasMany(c => c.Provinces).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Save>().HasMany(c => c.Pops).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            modelBuilder.Entity<Country>().HasOne(c => c.Save);
            modelBuilder.Entity<Country>().HasMany(c => c.Technologies).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasMany(c => c.Players).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            modelBuilder.Entity<Country>().HasMany(c => c.Families).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.OwnerId});
            modelBuilder.Entity<Country>().HasMany(c => c.Provinces).WithOne(x => x.Owner);
            modelBuilder.Entity<Country>().HasKey(c => new { c.SaveId, c.CountryId });
            modelBuilder.Entity<Country>().Ignore(c => c.PlayedBy);
            modelBuilder.Entity<Country>().Ignore(c => c.DisloyalPops);
            modelBuilder.Entity<Country>().Ignore(c => c.DisloyaltyPercentage);
            modelBuilder.Entity<Country>().Ignore(c => c.MilitaryTechnology);
            modelBuilder.Entity<Country>().Ignore(c => c.CivicTechnology);
            modelBuilder.Entity<Country>().Ignore(c => c.OratoryTechnology);
            modelBuilder.Entity<Country>().Ignore(c => c.ReligiousTechnology);
            modelBuilder.Entity<Family>().HasKey(c => new { c.SaveId, c.FamilyId });
            modelBuilder.Entity<Family>().HasOne(c => c.Save);
            modelBuilder.Entity<CountryPlayer>().HasKey(c => new { c.SaveId, c.CountryId, c.PlayerName });
            modelBuilder.Entity<CountryPlayer>().HasOne(c => c.Country);
            modelBuilder.Entity<CountryPlayer>().Property(c => c.PlayerName).HasMaxLength(100);
            modelBuilder.Entity<CountryTechnology>().HasKey(c => new { c.SaveId, c.CountryId, c.Type });
            modelBuilder.Entity<CountryTechnology>().HasOne(c => c.Country);
            modelBuilder.Entity<Province>().HasKey(c => new { c.SaveId, c.ProvinceId });
            modelBuilder.Entity<Province>().HasMany(c => c.Pops).WithOne(x => x.Province);
            modelBuilder.Entity<Province>().HasOne(c => c.Save);
            modelBuilder.Entity<Population>().HasKey(c => new { c.SaveId, c.PopId });
            modelBuilder.Entity<Population>().HasOne(c => c.Province);
            modelBuilder.Entity<Population>().HasOne(c => c.Save);
        }

    }
}
