using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Province
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int ProvinceId { get; set; }
        public string OriginalCulture { get; set; }
        public string OriginalReligion { get; set; }
        public string Culture { get; set; }
        public string Religion { get; set; }
        public double CivilizationValue { get; set; }
        public string TradeGood { get; set; }
        public virtual Country Owner { get; set; }
        public virtual Country Controller { get; set; }
        public virtual Country PreviousController { get; set; }
        public DateTime LastOwnerChange { get; set; }
        public DateTime LastControllerChange { get; set; }
        public ProvinceRank Rank { get; set; }
        public virtual ICollection<Population> Pops { get; set; } = new List<Population>();
    }
}
