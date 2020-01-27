using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryParser : Country, IParadoxRead
    {
        public CountryCurrencyDataParser CurrencyData { get; set; }
        public CountryTechnologiesParser Technology { get; set; }

        public CountryParser(SaveParser save, int countryId)
        {
            Save = save;
            SaveId = save.SaveId;
            CountryId = countryId;
        }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "tag":
                    Tag = parser.ReadString();
                    break;
                case "historical":
                    HistoricalTag = parser.ReadString();
                    break;
                case "country_name":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "flag":
                    FlagTag = parser.ReadString();
                    break;
                case "coat_of_arms":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "country_type":
                    parser.ReadString();
                    break;
                case "family":
                    parser.ReadString();
                    break;
                case "minor_family":
                    parser.ReadString();
                    break;
                case "variables":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "graphical_culture":
                    parser.ReadString();
                    break;
                case "gender_equality":
                    parser.ReadString();
                    break;
                case "color":
                    parser.ReadString();
                    break;
                case "color2":
                    parser.ReadString();
                    break;
                case "color3":
                    parser.ReadString();
                    break;
                case "has_coasts":
                    parser.ReadString();
                    break;
                case "num_stance_changes":
                    parser.ReadString();
                    break;
                case "currency_data":
                    CurrencyData = parser.Parse(new CountryCurrencyDataParser(this));
                    break;
                case "is_antagonist":
                    parser.ReadString();
                    break;
                case "capital":
                    parser.ReadString();
                    break;
                case "original_capital":
                    parser.ReadString();
                    break;
                case "current_regnal_number":
                    parser.ReadString();
                    break;
                case "historical_regnal_numbers":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "has_senior_ally":
                    parser.ReadString();
                    break;
                case "primary_culture":
                    parser.ReadString();
                    break;
                case "religion":
                    parser.ReadString();
                    break;
                case "military_tradition":
                    parser.ReadString();
                    break;
                case "diplomatic_stance":
                    parser.ReadString();
                    break;
                case "heritage":
                    parser.ReadString();
                    break;
                case "military_tradition_levels":
                    parser.ReadIntList();
                    break;
                case "sub_unit":
                    parser.ReadIntList();
                    break;
                case "sub_unit_access":
                    parser.ReadIntList();
                    break;
                case "combat_tactics":
                    parser.ReadIntList();
                    break;
                case "laws":
                    parser.ReadIntList();
                    break;
                case "ports":
                    parser.ReadIntList();
                    break;
                case "unit_counts":
                    parser.ReadIntList();
                    break;
                case "ideas":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "not_supporting_primary_heir":
                    parser.ReadInt32();
                    break;
                case "technology":
                    Technology = parser.Parse(new CountryTechnologiesParser(this));
                    break;
                case "recovery_motivation":
                    parser.ReadString();
                    break;
                case "starting_population":
                    StartingPopulation = parser.ReadInt32();
                    break;
                case "monthly_manpower":
                    MonthlyManpower = parser.ReadDouble();
                    break;
                case "current_income":
                    CurrentIncome = parser.ReadDouble();
                    break;
                case "estimated_monthly_income":
                    EstimatedMonthlyIncome = parser.ReadDouble();
                    break;
                case "averaged_income":
                    AveragedIncome = parser.ReadDouble();
                    break;
                case "economy":
                    parser.Parse(new CountryEconomyParser(this));
                    break;
                case "religious_unity":
                    ReligiousUnity = parser.ReadDouble();
                    break;
                case "foreign_religion_pops":
                    ForeignReligionPops = parser.ReadInt32();
                    break;
                case "total_population":
                    TotalPopulation = parser.ReadInt32();
                    break;
                case "succession":
                    parser.ReadString();
                    break;
                case "diplomatic_action":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "received_offers":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "omen":
                    parser.ReadString();
                    break;
                case "omen_start":
                    parser.ReadString();
                    break;
                case "omen_duration":
                    parser.ReadString();
                    break;
                case "possible_inventions_packed":
                    parser.ReadStringList();
                    break;
                case "government_key":
                    parser.ReadString();
                    break;
                case "succession_law":
                    parser.ReadString();
                    break;
                case "monarchy_military_reforms":
                    parser.ReadString();
                    break;
                case "monarchy_maritime_laws":
                    parser.ReadString();
                    break;
                case "monarchy_economic_law":
                    parser.ReadString();
                    break;
                case "monarchy_citizen_law":
                    parser.ReadString();
                    break;
                case "monarchy_religious_laws":
                    parser.ReadString();
                    break;
                case "monarchy_legitimacy_laws":
                    parser.ReadString();
                    break;
                case "monarchy_contract_law":
                    parser.ReadString();
                    break;
                case "monarchy_divinity_statutes":
                    parser.ReadString();
                    break;
                case "monarchy_subject_laws":
                    parser.ReadString();
                    break;
                case "republic_military_recruitment_laws":
                    parser.ReadString();
                    break;
                case "republic_election_reforms":
                    parser.ReadString();
                    break;
                case "corruption_laws":
                    parser.ReadString();
                    break;
                case "republican_mediterranean_laws":
                    parser.ReadString();
                    break;
                case "republican_religious_laws":
                    parser.ReadString();
                    break;
                case "republic_integration_laws":
                    parser.ReadString();
                    break;
                case "republic_citizen_laws":
                    parser.ReadString();
                    break;
                case "republican_land_reforms":
                    parser.ReadString();
                    break;
                case "republic_military_recruitment_laws_rom":
                    parser.ReadString();
                    break;
                case "republic_election_reforms_rom":
                    parser.ReadString();
                    break;
                case "corruption_laws_rom":
                    parser.ReadString();
                    break;
                case "republican_mediterranean_laws_rom":
                    parser.ReadString();
                    break;
                case "republican_religious_laws_rom":
                    parser.ReadString();
                    break; 
                case "republic_integration_laws_rom":
                    parser.ReadString();
                    break;
                case "republic_citizen_laws_rom":
                    parser.ReadString();
                    break;
                case "republican_land_reforms_rom":
                    parser.ReadString();
                    break;
                case "tribal_religious_law":
                    parser.ReadString();
                    break;
                case "tribal_currency_laws":
                    parser.ReadString();
                    break;
                case "tribal_centralization_law":
                    parser.ReadString();
                    break;
                case "tribal_authority_laws":
                    parser.ReadString();
                    break;
                case "tribal_autonomy_laws":
                    parser.ReadString();
                    break;
                case "tribal_domestic_laws":
                    parser.ReadString();
                    break;
                case "tribal_decentralized_laws":
                    parser.ReadString();
                    break;
                case "tribal_centralized_laws":
                    parser.ReadString();
                    break;
                case "tribal_super_decentralized_laws":
                    parser.ReadString();
                    break;
                case "tribal_super_centralized_laws":
                    parser.ReadString();
                    break;
                case "modifier":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "max_manpower":
                    MaxManpower = parser.ReadDouble();
                    break;
                case "blockaded_percent":
                    parser.ReadString();
                    break;
                case "blockaded_percent_per_province":
                    parser.ReadString();
                    break;
                case "units":
                    parser.ReadStringList();
                    break;
                case "active_inventions":
                    parser.ReadIntList();
                    break;
                case "export":
                    parser.ReadIntList();
                    break;
                case "economic_policies":
                    parser.ReadIntList();
                    break;
                case "monarch":
                    parser.ReadString();
                    break;
                case "ruler_term":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "country_characters_packed":
                    parser.ReadIntList();
                    break;
                case "successors":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "last_trade_route_creation_date":
                    parser.ReadString();
                    break;
                case "governorship":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "num_owned_provinces_per_year":
                    parser.ReadIntList();
                    break;
                case "total_holdings":
                    parser.ReadInt32();
                    break;
                case "possible_holdings":
                    parser.ReadInt32();
                    break;
                case "total_power_base":
                    TotalPowerBase = parser.ReadDouble();
                    break;
                case "non_loyal_power_base":
                    parser.ReadDouble();
                    break;
                 case "total_cohorts":
                    TotalCohorts = parser.ReadInt32();
                    break;
                case "num_ships_under_construction":
                    parser.ReadInt32();
                    break;
                case "num_regs_under_construction":
                    parser.ReadInt32();
                    break;
                case "num_forts_under_construction":
                    parser.ReadInt32();
                    break;
                case "loyal_cohorts":
                    LoyalCohorts = parser.ReadInt32();
                    break;
                case "disloyal_cohorts":
                    parser.ReadInt32();
                    break;
                case "loyal_pops":
                    LoyalPops = parser.ReadInt32();
                    break;
                case "defect_pops":
                    parser.ReadInt32();
                    break;
                case "centralization":
                    Centralization = parser.ReadDouble();
                    break;
                case "legitimacy":
                    Legitimacy = parser.ReadDouble();
                    break;
                case "primary":
                    parser.ReadString();
                    break;
                case "second":
                    parser.ReadString();
                    break;
                case "flank":
                    parser.ReadString();
                    break;
                case "last_war":
                    LastWar = parser.ReadDateTime();
                    break;
                case "last_battle_won":
                    LastBattleWon = parser.ReadDateTime();
                    break;
                case "cached_happiness_for_owned":
                    parser.ReadDoubleList();
                    break;
                case "cached_pop_count_for_owned":
                    parser.ReadDoubleList();
                    break;
                case "pooled_army_power":
                    parser.ReadDouble();
                    break;
                case "pirate_haven":
                    parser.ReadInt32();
                    break;
                case "ai":
                    parser.Parse(new IgnoredEntity());
                    break;
               
            }
        }
    }
}
