using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryTechnology: IParadoxRead
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public TechnologyType Type { get; set; }
        public int Level { get; set; }
        public double Progress { get; set; }
      

        public CountryTechnology(TechnologyType type, Country country)
        {
            Country = country;
            SaveId = country.SaveId;
            CountryId = country.CountryId;
            Type = type;
        }

        public CountryTechnology()
        {
           
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "level":
                    Level = parser.ReadInt32();
                    break;
                case "progress":
                    Progress = parser.ReadDouble();
                    break;
              
            }
           
        }
    }
}