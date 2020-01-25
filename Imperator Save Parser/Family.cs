using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class Family : IParadoxRead
    {
        public string Id { get; }
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

        public Family(string id)
        {
            Id = id;
        }
    }
}
