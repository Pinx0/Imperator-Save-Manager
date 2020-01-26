using Pdoxcl2Sharp;
using System.Collections.Generic;

namespace ImperatorSaveParser
{
    public class FamilyManager : IParadoxRead
    {
        public Save Save { get; set; }
        public IDictionary<string, Family> Families { get; private set; } = new Dictionary<string, Family>();
        public Family GetFamily(string id)
        {
            if(Families.ContainsKey(id))
                return Families[id];
            return null;
        }

        public FamilyManager(Save save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            Families = parser.ReadDictionary(x => x.ReadString(), x =>
            {
                if (x.NextIsBracketed())
                {
                    if(int.TryParse(x.CurrentString, out int id))
                        return x.Parse(new Family(Save, id));
                }

                x.ReadString();
                return null;
            });

        }

    }
}
