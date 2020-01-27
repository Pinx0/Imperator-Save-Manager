using Pdoxcl2Sharp;

namespace Imperator.Save.Parser
{
    public class CountryPlayerParser: CountryPlayer, IParadoxRead
    { 
        private readonly SaveParser _save;

        public CountryPlayerParser(SaveParser save)
        {
            SaveId = save.SaveId;
            _save = save;
        }
        public void TokenCallback(ParadoxParser parser, string token)
        {
            switch (token)
            {
                case "name":
                    PlayerName = parser.ReadString();
                    break;
                case "country":
                    CountryId = parser.ReadInt32();
                    Country = _save.CountriesDictionary[CountryId];
                    Country?.Players.Add(this);
                    break;
              
            }
           
        }
    }
}