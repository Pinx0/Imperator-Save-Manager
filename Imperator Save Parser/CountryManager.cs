﻿using Pdoxcl2Sharp;
using System.Collections.Generic;
using System.Linq;

namespace Imperator.Save.Parser
{
    public class CountryManager : IParadoxRead
    {
        public SaveParser Save { get; set; }
        public IDictionary<int, CountryParser> Countries { get; private set; } = new Dictionary<int, CountryParser>();
        public CountryManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Countries = parser.ReadDictionary( x =>
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
            Save.CountriesDictionary = Countries;
            foreach (var c in Countries.Values.Where(x => x != null))
            {
                Save.Countries.Add(c);
            }
        }
    }
}
