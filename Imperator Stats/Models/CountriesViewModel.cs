using System.Collections.Generic;
using Imperator.Save;

namespace ImperatorStats.Models
{
    public class CountriesViewModel
    {
        public IList<Country> Countries { get;  }

        public CountriesViewModel(IList<Country> countries)
        {
            Countries = countries;
        }
    }
}
