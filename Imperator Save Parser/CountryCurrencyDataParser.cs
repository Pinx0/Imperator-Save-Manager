using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryCurrencyDataParser: IParadoxRead
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public double Manpower { get; set; }
        public double Gold { get; set; }
        public double Stability { get; set; }
        public double Tyranny { get; set; }
        public double WarExhaustion { get; set; }
        public double AggressiveExpansion { get; set; }
        public double PoliticalInfluence { get; set; }
        public double MilitaryExperience { get; set; }
      

        public CountryCurrencyDataParser(Country country)
        {
            Country = country;
            CountryId = country.CountryId;
            SaveId = country.SaveId;
        }

        public CountryCurrencyDataParser()
        {
            
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "manpower":
                    Manpower = parser.ReadDouble();
                    break;
                case "gold":
                    Gold = parser.ReadDouble();
                    break;
                case "stability":
                    Stability = parser.ReadDouble();
                    break;
                case "tyranny":
                    Tyranny = parser.ReadDouble();
                    break;
                case "war_exhaustion":
                    WarExhaustion = parser.ReadDouble();
                    break;
                case "aggressive_expansion":
                    AggressiveExpansion = parser.ReadDouble();
                    break;
                case "political_influence":
                    PoliticalInfluence = parser.ReadDouble();
                    break;
                case "military_experience":
                    MilitaryExperience = parser.ReadDouble();
                    break;
            }
           
        }
    }
}