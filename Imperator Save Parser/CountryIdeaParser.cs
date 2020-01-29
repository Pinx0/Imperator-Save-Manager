using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryIdeaParser: CountryIdea, IParadoxRead
    { 
        public CountryIdeaParser(Country country)
        {
            Country = country;
            SaveId = country.SaveId;
            CountryId = country.CountryId;
            Country.Ideas.Add(this);
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "idea":
                    Name = parser.ReadString();
                    break;
                case "date":
                    Date = parser.ReadDateTime();
                    break;
              
            }
           
        }
    }
}