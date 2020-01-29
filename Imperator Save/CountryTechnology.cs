namespace Imperator.Save
{
    public class CountryTechnology
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public TechnologyType Type { get; set; }
        public int Level { get; set; }
        public double Progress { get; set; }
      
    }
}