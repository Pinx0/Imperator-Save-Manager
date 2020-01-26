using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace ImperatorSaveParser
{
    public class CountryManager : IParadoxRead
    {
        public Save Save { get; set; }
        public IDictionary<string, Country> Countries { get; private set; } = new Dictionary<string, Country>();

        public Country GetCountry(string id)
        {
            if(Countries.ContainsKey(id))
                return Countries[id];
            return null;
        }
        public CountryManager(Save save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Countries = parser.ReadDictionary(x => x.ReadString(), x =>
            {
                if (x.NextIsBracketed())
                {
                    if(int.TryParse(x.CurrentString, out int id))
                        return x.Parse(new Country(Save, id));
                }
                x.ReadString();
                return null;
            });
            foreach (var c in Countries.Values.Where(x => x != null))
            {
                Save.Countries.Add(c);
            };
        }
    }
}
