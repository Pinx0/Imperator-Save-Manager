using System.Collections.Generic;
using System.Linq;
using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryEconomy: IParadoxRead
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public double LastMonthIncome { get; set; }
        public ICollection<CountryEconomyTelemetry> Telemetries { get; set; } = new List<CountryEconomyTelemetry>();
        public CountryEconomyTelemetry Accumulated
        {
            get { return Telemetries.FirstOrDefault(x => x.Type == TelemetryType.Accumulated); }
        }
        public CountryEconomyTelemetry Spent
        {
            get { return Telemetries.FirstOrDefault(x => x.Type == TelemetryType.Spent); }
        }

        public CountryEconomy(Country country)
        {
            Country = country;
            SaveId = country.SaveId;
            CountryId = country.CountryId;
        }

        public CountryEconomy()
        {
            
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "lastmonthincome":
                    LastMonthIncome = parser.ReadDouble();
                    break;
                case "telemetry_accumulated":
                    Telemetries.Add(parser.Parse(new CountryEconomyTelemetry(TelemetryType.Accumulated, this)));
                    break;
                case "telemetry_spent":
                    Telemetries.Add(parser.Parse(new CountryEconomyTelemetry(TelemetryType.Spent, this)));
                    break;
              
            }
           
        }
    }
}