namespace Imperator.Save
{
    public class Population 
    {
        public Save Save { get; set; }
        public int SaveId { get; set; }
        public int PopId { get; set; }
        public PopType Type { get; set; }
        public string Culture { get; set; }
        public string Religion { get; set; }
        public Province Province { get; set; }
    }
}
