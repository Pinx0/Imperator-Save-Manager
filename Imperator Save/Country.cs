using System;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save
{
    public class Country 
    {
        public virtual  Save Save { get; set; }
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
        public virtual ICollection<CountryTechnology> Technologies { get; set; } = new List<CountryTechnology>();
        public virtual ICollection<CountryPlayer> Players { get; set; } = new List<CountryPlayer>();
        public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
        public virtual ICollection<Family> Families { get; set; } = new List<Family>();
        public virtual ICollection<Army> Armies { get; set; } = new List<Army>();
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
        public double AverageArmyExperience => Armies.Where(x => x.Class == ArmyClass.Land).Average(x => x.Experience);
        public double AverageArmyMorale => Armies.Where(x => x.Class == ArmyClass.Land).Average(x => x.Morale);
        public double AverageArmyStrength => Armies.Where(x => x.Class == ArmyClass.Land).Average(x => x.Strength);
        public double MercenaryPercent => Armies.Count(x => x.Class == ArmyClass.Land && x.Category == ArmyCategory.Mercenary) / (double)TotalCohorts;
        public double ClanPercent => Armies.Count(x => x.Class == ArmyClass.Land && x.Category == ArmyCategory.ClanRetinue) / (double)TotalCohorts;
        public int SameCulturePops => Provinces.SelectMany(p => p.Pops).Count(x => x.Culture == PrimaryCulture);
        public int SameCultureAndReligionPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Culture == PrimaryCulture && x.Religion == MainReligion);
        public int CitizenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Citizen);
        public int FreemenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Freeman);
        public int TribesmenPops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Tribesman);
        public int SlavePops => Provinces.SelectMany(p => p.Pops).Count(x => x.Type == PopType.Slave);
        public int TotalProvinces => Provinces.Count;
        public double AverageCivilization => Provinces.Sum(p => p.CivilizationValue * p.Pops.Count) / (double)Provinces.Sum(p => p.Pops.Count);
        public double PopulationDensity => TotalPopulation/(double)TotalProvinces;
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

        public int TotalArchers => Armies.Count(x => x.Type == ArmyType.Archers);
        public int TotalLightInfantry => Armies.Count(x => x.Type == ArmyType.LightInfantry);
        public int TotalHeavyInfantry => Armies.Count(x => x.Type == ArmyType.HeavyInfantry);
        public int TotalLightCavalry => Armies.Count(x => x.Type == ArmyType.LightCavalry);
        public int TotalHeavyCavalry => Armies.Count(x => x.Type == ArmyType.HeavyCavalry);
        public int TotalChariots => Armies.Count(x => x.Type == ArmyType.Chariots);
        public int TotalElephants => Armies.Count(x => x.Type == ArmyType.WarElephant);
        public int TotalHorseArchers => Armies.Count(x => x.Type == ArmyType.HorseArchers);
        public int TotalCamels => Armies.Count(x => x.Type == ArmyType.Camels);
        public int TotalSupplyTrains => Armies.Count(x => x.Type == ArmyType.SupplyTrain);
        public double ArchersPercent => TotalArchers / (double) TotalCohorts;
        public double LightInfantryPercent => TotalLightInfantry / (double) TotalCohorts;
        public double HeavyInfantryPercent => TotalHeavyInfantry / (double) TotalCohorts;
        public double LightCavalryPercent => TotalLightCavalry / (double) TotalCohorts;
        public double HeavyCavalryPercent => TotalHeavyCavalry / (double) TotalCohorts;
        public double ChariotsPercent => TotalChariots / (double) TotalCohorts;
        public double ElephantsPercent => TotalElephants / (double) TotalCohorts;
        public double HorseArchersPercent => TotalHorseArchers / (double) TotalCohorts;
        public double CamelsPercent => TotalCamels / (double) TotalCohorts;
        public double SupplyTrainsPercent => TotalSupplyTrains / (double) TotalCohorts;
    }
}
