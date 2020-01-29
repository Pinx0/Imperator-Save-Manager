using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class ArmyManager : IParadoxRead
    {
        private SaveParser Save { get; }
        public ArmyManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "subunit_database":
                    Save.ArmiesDictionary = parser.ReadDictionary( x =>
                    {
                        if (int.TryParse(x.ReadString(), out int id))
                            return id;
                        return 0;
                    }, x =>
                    {
                        if (x.NextIsBracketed())
                        {
                            if (int.TryParse(x.CurrentString, out int id))
                            {
                                return x.Parse(new ArmyParser(Save, id));
                            }
                        }
                        x.ReadString();
                        return null;
                    });
                    break;
                case "units_database":
                    parser.Parse(new IgnoredEntity());
                    break;
            }
            
        }
    }
}
