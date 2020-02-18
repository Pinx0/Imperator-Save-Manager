using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Save 
    {
        public int SaveId { get; set; }
        public string SaveKey { get; set; }
        public virtual Game Game { get; set; }
        public int GameId { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Family> Families { get; set; } = new List<Family>();
        public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
        public virtual ICollection<Population> Pops { get; set; } = new List<Population>();
        public virtual ICollection<Province> Provinces { get; set; } = new List<Province>();
    }
}
