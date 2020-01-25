using Pdoxcl2Sharp;
using System;
using System.Collections.Generic;

namespace ImperatorSaveParser
{
    public class CountryManager : IParadoxRead
    {
        public IDictionary<string, Country> Countries { get; private set; } = new Dictionary<string, Country>();

        public Country GetCountry(string id)
        {
            if(Countries.ContainsKey(id))
                return Countries[id];
            return null;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Countries = parser.ReadDictionary(x => x.ReadString(), countryReader);
        }
        private readonly Func<ParadoxParser, Country> countryReader = x =>
        {
            var id = x.CurrentString;
            if (x.NextIsBracketed())
            {
                return x.Parse(new Country(id));
            }
            x.ReadString();
            return null;
        };
    }
}
