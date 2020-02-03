using System.Collections.Generic;

namespace Imperator.Save
{
    public class CountryName
    {
        public string CountryTag { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; }
    }
}