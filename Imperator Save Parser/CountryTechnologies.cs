using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryTechnologies: IParadoxRead
    { 
        public CountryTechnology Military { get; set; }
        public CountryTechnology Civic { get; set; }
        public CountryTechnology Oratory { get; set; }
        public CountryTechnology Religious { get; set; }
     
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "military_tech":
                    Military = parser.Parse(new CountryTechnology());
                    break;
                case "civic_tech":
                    Civic = parser.Parse(new CountryTechnology());
                    break;
                case "oratory_tech":
                    Oratory = parser.Parse(new CountryTechnology());
                    break;
                case "religious_tech":
                    Religious = parser.Parse(new CountryTechnology());
                    break;
              
            }
           
        }
    }
}