using System.Collections.Generic;

namespace Imperator.Save
{
    public class ProvinceName
    {
        public int ProvinceId { get; set; }
        public string Name { get; set; }
        public ICollection<Province> Provinces { get; set; }
    }
}