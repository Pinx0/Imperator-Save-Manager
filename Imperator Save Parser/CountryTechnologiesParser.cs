using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryTechnologiesParser: IParadoxRead
    { 
        private CountryParser Country { get; }

        public CountryTechnologiesParser(CountryParser country)
        {
            Country = country;
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "military_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnologyParser(TechnologyType.Military, Country)));
                    break;
                case "civic_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnologyParser(TechnologyType.Civic,Country)));
                    break;
                case "oratory_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnologyParser(TechnologyType.Oratory,Country)));
                    break;
                case "religious_tech":
                    Country.Technologies.Add(parser.Parse(new CountryTechnologyParser(TechnologyType.Religious,Country)));
                    break;
              
            }
           
        }
    }
}