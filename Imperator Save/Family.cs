namespace Imperator.Save
{
    public class Family 
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int FamilyId { get; set; }
        public string Key { get; set; }
        public string Culture { get; set; }
        public double Prestige { get; set; }
        public virtual Country Country { get; set; }
        public int OwnerId { get; set; }
    }
}
