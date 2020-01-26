using System.Collections.Generic;
using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class EconomyViewModel
    {
        public IList<Country> Countries { get;  }

        public EconomyViewModel(IList<Country> countries)
        {
            Countries = countries;
        }
    }
}
