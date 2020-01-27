using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryTechnologyParser: CountryTechnology, IParadoxRead
    { 
        public CountryTechnologyParser(TechnologyType type, Country country)
        {
            Country = country;
            SaveId = country.SaveId;
            CountryId = country.CountryId;
            Type = type;
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