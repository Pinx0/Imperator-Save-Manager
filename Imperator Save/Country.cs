using System;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save
{
    public class Country 
    {
        public Save Save { get; set; }
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public string Tag { get; set; }
        public string HistoricalTag { get; set; }
        public string FlagTag { get; set; }
        public string PrimaryCulture { get; set; }
        public string MainReligion { get; set; }
        public string CountryType { get; set; }
        public double Manpower { get; set; }
        public double Gold { get; set; }
        public double Stability { get; set; }
        public double Tyranny { get; set; }
        public double WarExhaustion { get; set; }
        public double AggressiveExpansion { get; set; }
        public double PoliticalInfluence { get; set; }
        public double MilitaryExperience { get; set; }
        public ICollection<CountryTechnology> Technologies { get; set; } = new List<CountryTechnology>();
        public ICollection<CountryPlayer> Players { get; set; } = new List<CountryPlayer>();
        public ICollection<Province> Provinces { get; set; } = new List<Province>();
        public ICollection<Family> Families { get; set; } = new List<Family>();
        public int StartingPopulation { get; set; }
        public double MonthlyManpower { get; set; }
        public double CurrentIncome { get; set; }
        public double EstimatedMonthlyIncome { get; set; }
        public double AveragedIncome { get; set; }
        public double ReligiousUnity { get; set; }
        public double MaxManpower { get; set; }
        public int ForeignReligionPops { get; set; }
        public int TotalPopulation { get; set; }
        public int TotalCohorts { get; set; }
        public int LoyalPops { get; set; }
        public int LoyalCohorts { get; set; }
        public double TotalPowerBase { get; set; }
        public double Legitimacy { get; set; }
        public double Centralization { get; set; }
        public DateTime LastWar { get; set; }
        public DateTime LastBattleWon { get; set; }
        public double LastMonthIncome { get; set; }
        public double LastMonthExpense { get; set; }
        public double AccumulatedManpower { get; set; }
        public double AccumulatedGold { get; set; }
        public double AccumulatedStability { get; set; }
        public double AccumulatedTyranny { get; set; }
        public double AccumulatedWarExhaustion { get; set; }
        public double AccumulatedAggressiveExpansion { get; set; }
        public double AccumulatedPoliticalInfluence { get; set; }
        public double AccumulatedMilitaryExperience { get; set; }
        public double SpentManpower { get; set; }
        public double SpentGold { get; set; }
        public double SpentStability { get; set; }
        public double SpentTyranny { get; set; }
        public double SpentWarExhaustion { get; set; }
        public double SpentAggressiveExpansion { get; set; }
        public double SpentPoliticalInfluence { get; set; }
        public double SpentMilitaryExperience { get; set; }
        public double TotalMilitaryExperience => SpentMilitaryExperience + MilitaryExperience;
        public int SameCulturePops => Provinces.SelectMany(p => p.Pops).Count(x => x.Culture == PrimaryCulture);
        public int SameCultureAndReligionPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Culture == PrimaryCulture && x.Religion == MainReligion);
        public int CitizenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Citizen);
        public int FreemenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Freeman);
        public int TribesmenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Tribesman);
        public int SlavePops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Slave);
        public double CitizenFraction => CitizenPops/(double)TotalPopulation;
        public double FreemenFraction => FreemenPops/(double)TotalPopulation;
        public double TribesmenFraction => TribesmenPops/(double)TotalPopulation;
        public double SlavesFraction => SlavePops/(double)TotalPopulation;
        public double CulturalAndReligiousUnity => SameCultureAndReligionPops/(double)TotalPopulation;
        public double CulturalUnity => SameCulturePops/(double)TotalPopulation;
        public double LastMonthNetEarnings => LastMonthIncome - LastMonthExpense;
        public double PopulationGrowth => TotalPopulation / (double)StartingPopulation;
        public int DisloyalPops => TotalPopulation - LoyalPops;
        public double DisloyaltyPercentage => DisloyalPops / (double)TotalPopulation;
        public CountryTechnology MilitaryTechnology =>  Technologies.FirstOrDefault(x => x.Type == TechnologyType.Military);
        public CountryTechnology CivicTechnology =>  Technologies.FirstOrDefault(x => x.Type == TechnologyType.Civic);
        public CountryTechnology OratoryTechnology =>  Technologies.FirstOrDefault(x => x.Type == TechnologyType.Oratory);
        public CountryTechnology ReligiousTechnology =>  Technologies.FirstOrDefault(x => x.Type == TechnologyType.Religious);

        public string PlayedBy
        {
            get
            {
                if (Players.Count == 0) return "";
                return string.Join(", ", Players.Select(p => p.PlayerName).ToArray());
            }
        }

        public double AverageTechLevel => (MilitaryTechnology.Level + MilitaryTechnology.Progress / 100.0 +
                                          CivicTechnology.Level + CivicTechnology.Progress / 100.0 +
                                          OratoryTechnology.Level + OratoryTechnology.Progress / 100.0 +
                                          ReligiousTechnology.Level + ReligiousTechnology.Progress / 100.0)/4.0;

        
    }
}
