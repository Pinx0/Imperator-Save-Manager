using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryEconomyTelemetryParser: IParadoxRead
    { 
        private Country Country { get; }
        private TelemetryType Type { get; }
        public CountryEconomyTelemetryParser(TelemetryType type, CountryParser country)
        {
            Country = country;
            Type = type;

        }
     
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "manpower":
                    var mp = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentManpower = mp;
                    else Country.AccumulatedManpower = mp;
                    break;
                case "gold":
                    var g = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentGold = g;
                    else Country.AccumulatedGold = g;
                    break;
                case "stability":
                    var s = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentStability = s;
                    else Country.AccumulatedStability = s;
                    break;
                case "tyranny":
                    var t = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentTyranny = t;
                    else Country.AccumulatedTyranny = t;
                    break;
                case "war_exhaustion":
                    var we = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentWarExhaustion = we;
                    else Country.AccumulatedWarExhaustion = we;
                    break;
                case "aggressive_expansion":
                    var ae = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentAggressiveExpansion = ae;
                    else Country.AccumulatedAggressiveExpansion = ae;
                    break;
                case "political_influence":
                    var pi = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentPoliticalInfluence = pi;
                    else Country.AccumulatedPoliticalInfluence = pi;
                    break;
                case "military_experience":
                    var me = parser.ReadDouble();
                    if (Type == TelemetryType.Spent) Country.SpentMilitaryExperience = me;
                    else Country.AccumulatedMilitaryExperience = me;
                    break;

              
            }
           
        }
    }
}