using System.Linq;
using Pdoxcl2Sharp;

namespace ImperatorSaveParser
{
    public class CountryPlayer: IParadoxRead
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public string PlayerName { get; set; }
        public Country Country { get; set; }
        private readonly Save _save;

        public CountryPlayer(Save save)
        {
            SaveId = save.SaveId;
            _save = save;
        }

        public CountryPlayer()
        {
            
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
                    Country = _save.Countries.FirstOrDefault(x => x.CountryId == CountryId);
                    Country?.Players.Add(this);
                    break;
              
            }
           
        }
    }
}