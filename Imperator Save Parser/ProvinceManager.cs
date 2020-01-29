using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class ProvinceManager : IParadoxRead
    {
        private SaveParser Save { get; }
        public ProvinceManager(SaveParser save)
        {
            Save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            int.TryParse(token, out int pId);
            Save.ProvincesDictionary.Add(pId, parser.Parse(new ProvinceParser(Save, pId)));
        }
    }
}
