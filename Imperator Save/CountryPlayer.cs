namespace Imperator.Save
{
    public class CountryPlayer
    { 
        public int SaveId { get; set; }
        public int CountryId { get; set; }
        public string PlayerName { get; set; }
        public virtual Country Country { get; set; }
    }
}