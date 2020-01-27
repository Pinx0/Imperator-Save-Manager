using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save.Parser
{
    public class FamilyManager : IParadoxRead
    {
        public SaveParser Save { get; set; }
        public IDictionary<int, FamilyParser> Families { get; private set; } = new Dictionary<int, FamilyParser>();
        public FamilyManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Families = parser.ReadDictionary(
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
            Save.FamiliesDictionary = Families;
            foreach (var f in Families.Values.Where(f => f != null))
            {
                Save.Families.Add(f);
            }

        }

    }
}
