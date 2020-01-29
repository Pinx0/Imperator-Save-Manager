using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class ArmyParser : Army, IParadoxRead
    {
        public ArmyParser(SaveParser save, int armyId)
        {
            Save = save;
            SaveId = save.SaveId;
            ArmyId = armyId;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "subunit_name":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "category":
                    switch (parser.ReadString())
                    {
                        case "regular":
                            Category = ArmyCategory.Regular;
                            break;
                        case "mercenary":
                            Category = ArmyCategory.Mercenary;
                            break;
                        case "clan_retinue":
                            Category = ArmyCategory.ClanRetinue;
                            break;
                    }
                    break;
                case "home":
                    parser.ReadInt32();
                    break;
                case "type":
                    switch (parser.ReadString())
                    {
                        case "supply_train":
                            Type = ArmyType.SupplyTrain;
                            break;
                        case "archers":
                            Type = ArmyType.Archers;
                            break;
                        case "camels":
                            Type = ArmyType.Camels;
                            break;
                        case "heavy_infantry":
                            Type = ArmyType.HeavyInfantry;
                            break;
                        case "chariots":
                            Type = ArmyType.Chariots;
                            break;
                        case "light_cavalry":
                            Type = ArmyType.LightCavalry;
                            break;
                        case "heavy_cavalry":
                            Type = ArmyType.HeavyCavalry;
                            break;
                        case "light_infantry":
                            Type = ArmyType.LightInfantry;
                            break;
                        case "horse_archers":
                            Type = ArmyType.HorseArchers;
                            break;
                        case "warelephant":
                            Type = ArmyType.WarElephant;
                            break;
                        case "liburnian":
                            Type = ArmyType.Liburnian;
                            break;
                        case "tetrere":
                            Type = ArmyType.Tetrere;
                            break;
                        case "trireme":
                            Type = ArmyType.Trireme;
                            break;
                        case "hexere":
                            Type = ArmyType.Hexere;
                            break;
                        case "octere":
                            Type = ArmyType.Octere;
                            break;
                        case "mega_galley":
                            Type = ArmyType.MegaPolyrreme;
                            break;
                    }
                    break;
                case "morale":
                    Morale = parser.ReadDouble();
                    break;
                case "morale_damage":
                    parser.ReadDouble();
                    break;
                case "experience":
                    Experience = parser.ReadDouble();
                    break;
                case "strength":
                    Strength = parser.ReadDouble();
                    break;
                case "strength_damage":
                    parser.ReadDouble();
                    break;
                case "target":
                    parser.ReadString();
                    break;
                case "loyalty":
                    parser.ReadInt32();
                    break;
                case "country":
                    var c = parser.ReadInt32();
                    CountryId = c;
                    break;

            }
        }
    }
}
