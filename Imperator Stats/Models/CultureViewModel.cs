using System.Collections.Generic;
using System.Linq;
using Imperator.Save;
using ImperatorStats.Data;

namespace ImperatorStats.Models
{
    public class CultureViewModel
    {

        public Save Save { get; }
        public int TotalPops { get; }
        public List<CultureGrouping> Cultures { get; }

        public CultureViewModel(Save save, ImperatorContext db)
        {
            Save = save ?? new Save();
            TotalPops = db.Pops.Count(x => x.Province != null && x.SaveId == Save.SaveId);
            Cultures = db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.CultureId)
                .Select(x => new CultureGrouping {CultureId = x.Key, PopsCount = x.Count()}).OrderByDescending(x => x.PopsCount).ToList();
            var dictionary = db.Cultures.ToList().ToDictionary(x => x.CultureId, y => y);
            foreach (var c in Cultures)
            {
                if(dictionary.ContainsKey(c.CultureId))
                    c.Culture = dictionary[c.CultureId];
            }
        }
    }
}
