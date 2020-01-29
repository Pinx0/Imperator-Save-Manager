using System.ComponentModel.DataAnnotations.Schema;
using Imperator.Save;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ImperatorStats.Data
{
    public class SaveMap : IEntityTypeConfiguration<Save>
    {
        public void Configure(EntityTypeBuilder<Save> builder)
        {
            builder.HasKey(c => c.SaveId).HasAnnotation("DatabaseGenerated",DatabaseGeneratedOption.Identity);
            builder.HasMany(c => c.Families).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            builder.HasMany(c => c.Countries).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            builder.HasMany(c => c.Provinces).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
            builder.HasMany(c => c.Pops).WithOne(x => x.Save).HasForeignKey(x => x.SaveId);
        }
    }

    public class CountryMap : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasOne(c => c.Save);
            builder.HasMany(c => c.Technologies).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            builder.HasMany(c => c.Players).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            builder.HasMany(c => c.Families).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.OwnerId});
            builder.HasMany(c => c.Armies).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            builder.HasMany(c => c.Ideas).WithOne(x => x.Country).HasForeignKey(x => new {x.SaveId, x.CountryId});
            builder.HasMany(c => c.Provinces).WithOne(x => x.Owner);
            builder.HasKey(c => new { c.SaveId, c.CountryId });
            builder.Ignore(c => c.PlayedBy);
            builder.Ignore(c => c.DisloyalPops);
            builder.Ignore(c => c.DisloyaltyPercentage);
            builder.Ignore(c => c.MilitaryTechnology);
            builder.Ignore(c => c.CivicTechnology);
            builder.Ignore(c => c.OratoryTechnology);
            builder.Ignore(c => c.ReligiousTechnology);
        }
    }
    public class FamilyMap : IEntityTypeConfiguration<Family>
    {
        public void Configure(EntityTypeBuilder<Family> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.FamilyId });
            builder.HasOne(c => c.Save);
        }
    }
    public class CountryPlayerMap : IEntityTypeConfiguration<CountryPlayer>
    {
        public void Configure(EntityTypeBuilder<CountryPlayer> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.CountryId, c.PlayerName });
            builder.HasOne(c => c.Country);
            builder.Property(c => c.PlayerName).HasMaxLength(100);
        }
    }
    public class CountryTechnologyMap : IEntityTypeConfiguration<CountryTechnology>
    {
        public void Configure(EntityTypeBuilder<CountryTechnology> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.CountryId, c.Type });
            builder.HasOne(c => c.Country);
        }
    }
    public class CountryIdeaMap : IEntityTypeConfiguration<CountryIdea>
    {
        public void Configure(EntityTypeBuilder<CountryIdea> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.CountryId, c.Name });
            builder.HasOne(c => c.Country);
            builder.Property(c => c.Name).HasMaxLength(100);
        }
    }
    public class ArmyMap : IEntityTypeConfiguration<Army>
    {
        public void Configure(EntityTypeBuilder<Army> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.ArmyId });
            builder.HasOne(c => c.Country);
        }
    }
    public class ProvinceMap : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.ProvinceId });
            builder.HasMany(c => c.Pops).WithOne(x => x.Province);
            builder.HasOne(c => c.Save);
        }
    }
    public class PopulationMap : IEntityTypeConfiguration<Population>
    {
        public void Configure(EntityTypeBuilder<Population> builder)
        {
            builder.HasKey(c => new { c.SaveId, c.PopId });
            builder.HasOne(c => c.Province);
            builder.HasOne(c => c.Save);
        }
    }
}
