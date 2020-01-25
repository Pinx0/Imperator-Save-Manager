using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryEconomy: IParadoxRead
    { 
        public CountryEconomyTelemetry Accumulated { get; set; }
        public CountryEconomyTelemetry Spent { get; set; }
     
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "telemetry_accumulated":
                    Accumulated = parser.Parse(new CountryEconomyTelemetry());
                    break;
                case "telemetry_spent":
                    Spent = parser.Parse(new CountryEconomyTelemetry());
                    break;
              
            }
           
        }
    }
}