using System.Linq;
using Imperator.Save;
using ImperatorStats.Data;
using Microsoft.EntityFrameworkCore;

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
        public Province MostPopulatedCity => _db.Provinces.Where(x => x.Rank == ProvinceRank.City  && x.SaveId == Save.SaveId).Include(x => x.Name).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public Province MostPopulatedSettlement => _db.Provinces.Where(x => x.Rank == ProvinceRank.Settlement  && x.SaveId == Save.SaveId).Include(x => x.Name).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public Province MostPopulatedMetropolis => _db.Provinces.Where(x => x.Rank == ProvinceRank.Metropolis  && x.SaveId == Save.SaveId).Include(x => x.Name).OrderByDescending(x => x.Pops.Count).FirstOrDefault();
        public Province MostBuildingsProvince => _db.Provinces.Where(x => x.SaveId == Save.SaveId).Include(x => x.Name).OrderByDescending(x => x.TotalBuildings).FirstOrDefault();
        public int MostPopulatedCityPops => _db.Pops.Count(x => x.Province == MostPopulatedCity && x.SaveId == Save.SaveId);
        public int MostPopulatedSettlementPops => _db.Pops.Count(x => x.Province == MostPopulatedSettlement && x.SaveId == Save.SaveId);
        public int MostPopulatedMetropolisPops => MostPopulatedMetropolis == null ? 0 : _db.Pops.Count(x => x.Province == MostPopulatedMetropolis && x.SaveId == Save.SaveId);
        public ReligionGrouping MostSpreadReligion
        {
            get
            {
                var religion = _db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId).GroupBy(x => x.ReligionId)
                    .Select(x => new ReligionGrouping {ReligionId = x.Key, PopsCount = x.Count()})
                    .OrderByDescending(x => x.PopsCount).First();
                religion.Religion = _db.Religions.Find(religion.ReligionId);
                return religion;
            }
        }

        public double MostSpreadReligionPercent => MostSpreadReligion.PopsCount / (double) TotalPops;
        public CultureGrouping MostCommonCultureGrouping
        {
            get
            {
                var culture = _db.Pops.Where(x => x.Province != null && x.SaveId == Save.SaveId)
                    .GroupBy(x => x.CultureId)
                    .Select(x => new CultureGrouping {CultureId = x.Key, PopsCount = x.Count()})
                    .OrderByDescending(x => x.PopsCount).First();

                culture.Culture = _db.Cultures.Find(culture.CultureId);
                return culture;
            }
        }

        public double MostCommonCulturePercent => MostCommonCultureGrouping.PopsCount / (double) TotalPops;
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
            Save = save ?? new Save();
            _db = db;
        }
    }
}
