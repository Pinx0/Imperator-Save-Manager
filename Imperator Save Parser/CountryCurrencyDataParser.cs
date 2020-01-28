using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryCurrencyDataParser: IParadoxRead
    { 
        private CountryParser Country { get; }

        public CountryCurrencyDataParser(CountryParser country)
        {
            Country = country;
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "manpower":
                    Country.Manpower = parser.ReadDouble();
                    break;
                case "gold":
                    Country.Gold = parser.ReadDouble();
                    break;
                case "stability":
                    Country.Stability = parser.ReadDouble();
                    break;
                case "tyranny":
                    Country.Tyranny = parser.ReadDouble();
                    break;
                case "war_exhaustion":
                    Country.WarExhaustion = parser.ReadDouble();
                    break;
                case "aggressive_expansion":
                    Country.AggressiveExpansion = parser.ReadDouble();
                    break;
                case "political_influence":
                    Country.PoliticalInfluence = parser.ReadDouble();
                    break;
                case "military_experience":
                    Country.MilitaryExperience = parser.ReadDouble();
                    break;
            }
           
        }
    }
}