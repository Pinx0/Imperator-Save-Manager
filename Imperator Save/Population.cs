namespace Imperator.Save
{
    public class Population 
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int PopId { get; set; }
        public PopType Type { get; set; }
        public string Culture { get; set; }
        public string Religion { get; set; }
        public virtual Province Province { get; set; }
    }
}
