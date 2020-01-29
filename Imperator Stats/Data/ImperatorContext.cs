using System.Linq;
using System.Reflection;
using Imperator.Save;
using Imperator.Save.Parser;
using Microsoft.EntityFrameworkCore;

namespace ImperatorStats.Data
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
        public DbSet<CountryIdea> CountryIdeas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseLazyLoadingProxies();
        }
        public ImperatorContext(DbContextOptions<ImperatorContext> options) : base(options)
        {
        }

        public int BulkSave(SaveParser save)
        {
            Saves.Add(save);
            SaveChanges();
            save.UpdateSaveId();
            this.BulkInsert(save.FamiliesDictionary.Values.Where(f => f != null));
            this.BulkInsert(save.PopsDictionary.Values.Where(f => f != null));
            this.BulkInsert(save.CountriesDictionary.Values.Where(f => f != null));
            this.BulkInsert(save.CountriesDictionary.Values.Where(f => f != null).SelectMany(c => c.Players));
            this.BulkInsert(save.CountriesDictionary.Values.Where(f => f != null).SelectMany(c => c.Technologies));
            this.BulkInsert(save.CountriesDictionary.Values.Where(f => f != null).SelectMany(c => c.Ideas));
            this.BulkInsert(save.ProvincesDictionary.Values.Where(f => f != null));
            this.BulkInsert(save.ArmiesDictionary.Values.Where(f => f != null));
            return save.SaveId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
