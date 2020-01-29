using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryIdeaManager : IParadoxRead
    {
        private CountryParser Country { get; }
        public CountryIdeaManager(CountryParser country)
        {
            Country = country;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "idea":
                    parser.Parse(new CountryIdeaParser(Country));
                    break;
            }
            
        }
    }
}
