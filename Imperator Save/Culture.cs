using System.Collections.Generic;

namespace Imperator.Save
{
    public class Culture
    {
        public string CultureId { get; set; }
        public string Name { get; set; }
        public ICollection<Population> Pops { get; set; }
    }
}