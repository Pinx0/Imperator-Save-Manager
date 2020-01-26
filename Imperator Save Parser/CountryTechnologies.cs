using System.Collections.Generic;
using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryTechnologies: IParadoxRead
    { 
        public Country Country { get; set; }

        public CountryTechnologies(Country country)
        {
            Country = country;
        }

        public CountryTechnologies()
        {
            
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