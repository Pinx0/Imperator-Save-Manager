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
        public List<Culture> Cultures { get; }

        public CultureViewModel(Save save, ImperatorContext db)
        {
            Save = save;
            TotalPops = db.Pops.Count(x => x.Province != null && x.SaveId == Save.SaveId);
            Cultures = db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.Culture)
                .Select(x => new Culture {Name = x.Key, PopsCount = x.Count()}).OrderByDescending(x => x.PopsCount).ToList();
        }
    }
}
