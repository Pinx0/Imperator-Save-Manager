using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class FamilyParser : Family, IParadoxRead
    {
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "key":
                    Key = parser.ReadString();
                    break;
                case "owner":
                    OwnerId = parser.ReadInt32();
                    break;
                case "prestige":
                    Prestige = parser.ReadDouble();
                    break;
                case "color":
                    parser.ReadInt32();
                    break;
                case "member":
                    parser.ReadIntList();
                    break;
                case "culture":
                    Culture = parser.ReadString();
                    break;
            }
           
        }
        
        public FamilyParser(SaveParser save, int familyId)
        {
            Save = save;
            SaveId = save.SaveId;
            FamilyId = familyId;
        }
    }
}
