using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save.Parser
{
    public class CountryManager : IParadoxRead
    {
        private SaveParser Save { get; }
        public CountryManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Save.CountriesDictionary = parser.ReadDictionary( x =>
            {
                if (int.TryParse(x.ReadString(), out int id))
                    return id;
                return 0;
            }, x =>
            {
                if (x.NextIsBracketed())
                {
                    if(int.TryParse(x.CurrentString, out int id))
                        return x.Parse(new CountryParser(Save, id));
                }
                x.ReadString();
                return null;
            });
        }
    }
}
