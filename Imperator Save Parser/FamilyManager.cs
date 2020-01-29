using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class FamilyManager : IParadoxRead
    {
        private SaveParser Save { get; }
        public FamilyManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Save.FamiliesDictionary = parser.ReadDictionary(
                x =>
                {
                    if (int.TryParse(x.ReadString(), out int id))
                        return id;
                    return 0;
                },
            x =>
            {
                if (x.NextIsBracketed())
                {
                    if(int.TryParse(x.CurrentString, out int id))
                        return x.Parse(new FamilyParser(Save, id));
                }

                x.ReadString();
                return null;
            });
        }
    }
}
