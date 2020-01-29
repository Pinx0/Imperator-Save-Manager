using System.Linq;
using Imperator.Save;
using ImperatorStats.Data;

namespace ImperatorStats.Models
{
    public class FactsViewModel
    {

        private readonly ImperatorContext _db;
        public int TotalPops => _db.Pops.Count(x => x.Province != null && x.SaveId == Save.SaveId);
        public int TotalProvinces => _db.Provinces.Count(x => x.SaveId == Save.SaveId);
        public int GrowingPops => _db.Pops.Count(x => x.Province == null && x.SaveId == Save.SaveId);
        public double TotalGold => _db.Countries.Where(x => x.SaveId == Save.SaveId).Sum(x => x.Gold);
        public double TotalSpentGold => _db.Countries.Where(x => x.SaveId == Save.SaveId).Sum(x => x.SpentGold);
        public double TotalGoldLastMonth => _db.Countries.Where(x => x.SaveId == Save.SaveId).Sum(x => x.LastMonthIncome);
        public double TotalGoldSpentLastMonth => _db.Countries.Where(x => x.SaveId == Save.SaveId).Sum(x => x.LastMonthExpense);
        public double TotalNetGoldLastMonth => _db.Countries.Where(x => x.SaveId == Save.SaveId).Sum(x => x.LastMonthIncome - x.LastMonthExpense);
        public Province MostPopulatedCity => _db.Provinces.Where(x => x.Rank == ProvinceRank.City  && x.SaveId == Save.SaveId).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public Province MostPopulatedSettlement => _db.Provinces.Where(x => x.Rank == ProvinceRank.Settlement  && x.SaveId == Save.SaveId).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public Province MostPopulatedMetropolis => _db.Provinces.Where(x => x.Rank == ProvinceRank.Metropolis  && x.SaveId == Save.SaveId).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public int MostPopulatedCityPops => _db.Pops.Count(x => x.Province == MostPopulatedCity && x.SaveId == Save.SaveId);
        public int MostPopulatedSettlementPops => _db.Pops.Count(x => x.Province == MostPopulatedSettlement && x.SaveId == Save.SaveId);
        public int MostPopulatedMetropolisPops => MostPopulatedMetropolis == null ? 0 : _db.Pops.Count(x => x.Province == MostPopulatedMetropolis && x.SaveId == Save.SaveId);
        public Religion MostSpreadReligion => _db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.Religion).Select(x => new Religion{Name = x.Key, PopsCount = x.Count()}).OrderByDescending(x => x.PopsCount).First();
        public double MostSpreadReligionPercent => MostSpreadReligion.PopsCount / (double) TotalPops;
        public Culture MostCommonCulture => _db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.Culture).Select(x => new Culture{Name = x.Key, PopsCount = x.Count()}).OrderByDescending(x => x.PopsCount).First();
        public double MostCommonCulturePercent => MostCommonCulture.PopsCount / (double) TotalPops;
        public Save Save { get;  }
        public int CitizenPops => _db.Pops.Count(x => x.SaveId == Save.SaveId && x.Type == PopType.Citizen);
        public int FreemenPops => _db.Pops.Count(x => x.SaveId == Save.SaveId && x.Type == PopType.Freeman);
        public int TribesmenPops => _db.Pops.Count(x => x.SaveId == Save.SaveId && x.Type == PopType.Tribesman);
        public int SlavePops => _db.Pops.Count(x => x.SaveId == Save.SaveId && x.Type == PopType.Slave);
        public double CitizenPopsPercent => CitizenPops / (double)TotalPops;
        public double FreemenPopsPercent => FreemenPops / (double)TotalPops;
        public double TribesmenPopsPercent => CitizenPops / (double)TotalPops;
        public double SlavePopsPercent => SlavePops / (double)TotalPops;


        public FactsViewModel(Save save, ImperatorContext db)
        {
            Save = save;
            _db = db;
        }
    }
}
