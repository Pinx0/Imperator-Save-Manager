using System.Collections.Generic;
using System.Linq;
using Imperator.Save;
using ImperatorStats.Data;

namespace ImperatorStats.Models
{
    public class TradeGoodsViewModel
    {

        public Save Save { get; }
        public int TotalProvinces { get; }
        public int TotalProduction { get; }
        public List<TradeGood> TradeGoods { get; }

        public TradeGoodsViewModel(Save save, ImperatorContext db)
        {
            Save = save ?? new Save();
            TotalProvinces = db.Provinces.Count(x => x.SaveId == Save.SaveId && x.TradeGood != null);
            TradeGoods = db.Provinces.Where(x => x.SaveId == Save.SaveId && x.TradeGood != null).GroupBy(x => x.TradeGood)
                .Select(x => new TradeGood {Name = x.Key, Quantity = x.Count(), QuantityProduced =  x.Count()}).OrderByDescending(x => x.Quantity).ToList();
            TotalProduction = TradeGoods.Sum(x => x.QuantityProduced);
        }
    }
}
