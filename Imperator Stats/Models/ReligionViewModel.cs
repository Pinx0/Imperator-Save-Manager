using System.Collections.Generic;
using System.Linq;
using Imperator.Save;
using ImperatorStats.Data;

namespace ImperatorStats.Models
{
    public class ReligionViewModel
    {

        public Save Save { get; }
        public int TotalPops { get; }
        public List<ReligionGrouping> Religions { get; }

        public ReligionViewModel(Save save, ImperatorContext db)
        {
            Save = save;
            TotalPops = db.Pops.Count(x => x.Province != null && x.SaveId == Save.SaveId);
            Religions = db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.ReligionId)
                .Select(x => new ReligionGrouping {ReligionId = x.Key, PopsCount = x.Count()}).OrderByDescending(x => x.PopsCount).ToList();
            var dictionary = db.Religions.ToList().ToDictionary(x => x.ReligionId, y => y);
            foreach (var c in Religions)
            {
                if(dictionary.ContainsKey(c.ReligionId))
                    c.Religion = dictionary[c.ReligionId];
            }
        }
    }
}
