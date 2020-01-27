using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Save 
    {
        public int SaveId { get; set; }
        public string SaveKey { get; set; }
        public ICollection<Family> Families { get; set; } = new List<Family>();
        public ICollection<Country> Countries { get; set; } = new List<Country>();
        public ICollection<Population> Pops { get; set; } = new List<Population>();
        public ICollection<Province> Provinces { get; set; } = new List<Province>();
        public DateTime Date { get; set; }
    }
}
