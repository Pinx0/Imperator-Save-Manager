using Pdoxcl2Sharp;
using System.Collections.Generic;

namespace Imperator.Save.Parser
{
    public class ProvinceManager : IParadoxRead
    {
        public SaveParser Save { get; set; }
        public IDictionary<int, ProvinceParser> Provinces { get; private set; } = new Dictionary<int, ProvinceParser>();
        public ProvinceManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            int.TryParse(token, out int pId);
            Provinces.Add(pId, parser.Parse(new ProvinceParser(Save, pId)));
        }
    }
}
