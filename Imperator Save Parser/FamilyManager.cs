using Pdoxcl2Sharp;
using System;
using System.Collections.Generic;

namespace ImperatorSaveParser
{
    public class FamilyManager : IParadoxRead
    {
        public IDictionary<string, Family> Families { get; private set; } = new Dictionary<string, Family>();
        public Family GetFamily(string id)
        {
            if(Families.ContainsKey(id))
                return Families[id];
            return null;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Families = parser.ReadDictionary(x => x.ReadString(), familyReader);

        }
        private readonly Func<ParadoxParser, Family> familyReader = x =>
        {
            var id = x.CurrentString;
            if (x.NextIsBracketed())
            {
                return x.Parse(new Family(id));
            }
            x.ReadString();
            return null;
        };
    }
}
