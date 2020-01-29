using System;
using System.Collections.Generic;

namespace Imperator.Save
{
    public class Army
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int ArmyId { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public ArmyType Type { get; set; }
        public ArmyCategory Category { get; set; }
        public double Morale { get; set; }
        public double Experience { get; set; }
        public double Strength { get; set; }
        public ArmyClass Class => (int)Type >= 100 ? ArmyClass.Naval : ArmyClass.Land;
    }
}
