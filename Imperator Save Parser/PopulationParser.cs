using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class PopulationParser : Population, IParadoxRead
    {
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "type":
                    switch (parser.ReadString())
                    {
                        case "citizen":
                            Type = PopType.Citizen;
                            break;
                        case "freemen":
                            Type = PopType.Freeman;
                            break;
                        case "tribesmen":
                            Type = PopType.Tribesman;
                            break;
                        case "slaves":
                            Type = PopType.Slave;
                            break;
                    }
                    break;
                case "culture":
                    Culture = parser.ReadString();
                    break;
                case "religion":
                    Religion = parser.ReadString();
                    break;
            }
        }

        public PopulationParser(SaveParser save, int popId)
        {
            Save = save;
            SaveId = save.SaveId;
            PopId = popId;
        }
    }
}
