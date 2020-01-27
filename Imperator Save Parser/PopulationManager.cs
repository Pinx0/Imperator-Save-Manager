using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save.Parser
{
    public class PopulationManager : IParadoxRead
    {
        public SaveParser Save { get; set; }
        public IDictionary<int, PopulationParser> Pops { get; private set; } = new Dictionary<int, PopulationParser>();
        public PopulationManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Pops = parser.ReadDictionary( x =>
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
                        return x.Parse(new PopulationParser(Save, id));
                    }
                }
                x.ReadString();
                return null;
            });
            Save.PopsDictionary = Pops;
            foreach (var c in Pops.Values.Where(x => x != null))
            {
                Save.Pops.Add(c);
            }
        }
    }
}
