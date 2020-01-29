using System;

namespace Imperator.Save
{
    public class CountryIdea
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
      
    }
}