using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class ProvinceParser : Province, IParadoxRead
    {
        private SaveParser SaveParser { get; }
        public ProvinceParser(SaveParser save, int provinceId)
        {
            SaveParser = save;
            Save = save;
            SaveId = save.SaveId;
            ProvinceId = provinceId;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "province_name":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "variables":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "original_culture":
                    OriginalCulture = parser.ReadString();
                    break;
                case "original_religion":
                    OriginalReligion = parser.ReadString();
                    break;
                case "culture":
                    Culture = parser.ReadString();
                    break;
                case "religion":
                    Religion = parser.ReadString();
                    break;
                case "state":
                    parser.ReadInt32();
                    break;
                case "owner":
                    var ownerId = parser.ReadInt32();
                    Owner = SaveParser.CountriesDictionary[ownerId];
                    Owner.Provinces.Add(this);
                    break;
                case "controller":
                    Controller = SaveParser.CountriesDictionary[parser.ReadInt32()];
                    break;
                case "previous_controller":
                    PreviousController = SaveParser.CountriesDictionary[parser.ReadInt32()];
                    break;
                case "last_owner_change":
                    LastOwnerChange = parser.ReadDateTime();
                    break;
                case "last_controller_change":
                    LastControllerChange = parser.ReadDateTime();
                    break;
                case "claim":
                    parser.ReadInt32();
                    break;
                case "pop":
                    var pop = SaveParser.PopsDictionary[parser.ReadInt32()];
                    pop.Province = this;
                    Pops.Add(pop);
                    break;
                case "growing_pop":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "migrant":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "assimilate":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "convert":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "promote":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "demote":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "civilization_value":
                    CivilizationValue = parser.ReadInt32();
                    break;
                case "trade_goods":
                    TradeGood = parser.ReadString();
                    break;
                case "num_foreign_culture":
                    parser.ReadInt32();
                    break;
                case "num_other_religion":
                    parser.ReadInt32();
                    break;
                case "blockaded":
                    parser.ReadString();
                    break;
                case "blockaded_percent_per_navy":
                    parser.ReadDouble();
                    break;
                case "province_rank":
                    switch (parser.ReadString())
                    {
                        case "settlement":
                            Rank = ProvinceRank.Settlement;
                            break;
                        case "city":
                            Rank = ProvinceRank.City;
                            break;
                        case "metropolis":
                            Rank = ProvinceRank.Metropolis;
                            break;
                    }
                    break;
                case "buildings":
                    parser.ReadIntList();
                    break;
                case "looted":
                     parser.ReadDateTime();
                    break;
                case "plundered":
                    parser.ReadDateTime();
                    break;
                case "winter_neighbours":
                    parser.ReadInt32();
                    break;

            }
        }
    }
}
