using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryEconomyParser: IParadoxRead
    { 
        public CountryParser Country { get; }
        public CountryEconomyParser(CountryParser country)
        {
            Country = country;
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "lastmonthincome":
                    Country.LastMonthIncome = parser.ReadDouble();
                    break;
                case "lastmonthexpense":
                    Country.LastMonthExpense = parser.ReadDouble();
                    break;
                case "telemetry_accumulated":
                    parser.Parse(new CountryEconomyTelemetryParser(TelemetryType.Accumulated, Country));
                    break;
                case "telemetry_spent":
                    parser.Parse(new CountryEconomyTelemetryParser(TelemetryType.Spent, Country));
                    break;
              
            }
           
        }
    }
}