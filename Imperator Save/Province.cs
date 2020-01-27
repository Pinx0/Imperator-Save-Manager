using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Province
    {
        public Save Save { get; set; }
        public int SaveId { get; set; }
        public int ProvinceId { get; set; }
        public string OriginalCulture { get; set; }
        public string OriginalReligion { get; set; }
        public string Culture { get; set; }
        public string Religion { get; set; }
        public int CivilizationValue { get; set; }
        public string TradeGood { get; set; }
        public Country Owner { get; set; }
        public Country Controller { get; set; }
        public Country PreviousController { get; set; }
        public DateTime LastOwnerChange { get; set; }
        public DateTime LastControllerChange { get; set; }
        public ProvinceRank Rank { get; set; }
        public ICollection<Population> Pops { get; set; } = new List<Population>();
    }
}
