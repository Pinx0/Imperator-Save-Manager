using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class Family : IParadoxRead
    {
        public Save Save { get; set; }
        public int SaveId { get; set; }
        public int FamilyId { get; set; }
        public string Key { get; private set; }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "key":
                    Key = parser.ReadString();
                    break;
            }
           
        }

        public Family(Save save, int familyId)
        {
            Save = save;
            SaveId = save.SaveId;
            FamilyId = familyId;
        }

        public Family()
        {
            
        }
    }
}
