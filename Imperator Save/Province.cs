using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Province
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int ProvinceId { get; set; }
        public Culture OriginalCulture { get; set; }
        public string OriginalCultureId { get; set; }
        public Religion OriginalReligion { get; set; }
        public string OriginalReligionId { get; set; }
        public Culture Culture { get; set; }
        public string CultureId { get; set; }
        public Religion Religion { get; set; }
        public string ReligionId { get; set; }
        public double CivilizationValue { get; set; }
        public string TradeGood { get; set; }
        public int TotalBuildings { get; set; }
        public virtual Country Owner { get; set; }
        public virtual int? OwnerId { get; set; }
        public virtual Country Controller { get; set; }
        public virtual int? ControllerId { get; set; }
        public virtual Country PreviousController { get; set; }
        public virtual int? PreviousControllerId { get; set; }
        public DateTime LastOwnerChange { get; set; }
        public DateTime LastControllerChange { get; set; }
        public ProvinceRank Rank { get; set; }
        public virtual ICollection<Population> Pops { get; set; } = new List<Population>();
        public virtual ProvinceName Name { get; set; }
        
    }
}
