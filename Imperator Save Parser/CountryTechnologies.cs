using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryTechnologies: IParadoxRead
    { 
        public Country Country { get; }

        public CountryTechnologies(Country country)
        {
            Country = country;
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "military_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnology(TechnologyType.Military, Country)));
                    break;
                case "civic_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnology(TechnologyType.Civic,Country)));
                    break;
                case "oratory_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnology(TechnologyType.Oratory,Country)));
                    break;
                case "religious_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnology(TechnologyType.Religious,Country)));
                    break;
              
            }
           
        }
    }
}