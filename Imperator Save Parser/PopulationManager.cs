using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save.Parser
{
    public class PopulationManager : IParadoxRead
    {
        private SaveParser Save { get; }
        public PopulationManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Save.PopsDictionary = parser.ReadDictionary( x =>
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
            foreach (var c in Save.PopsDictionary.Values.Where(x => x != null))
            {
                Save.Pops.Add(c);
            }
        }
    }
}
