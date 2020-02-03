using System.Collections.Generic;

namespace Imperator.Save
{
    public class Religion
    {
        public string ReligionId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Population> Pops { get; set; }
    }
}