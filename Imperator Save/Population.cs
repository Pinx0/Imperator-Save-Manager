namespace Imperator.Save
{
    public class Population 
    {
        public virtual Save Save { get; set; }
        public int SaveId { get; set; }
        public int PopId { get; set; }
        public PopType Type { get; set; }
        public virtual Culture Culture { get; set; }
        public virtual Religion Religion { get; set; }
        public string ReligionId { get; set; }
        public string CultureId { get; set; }
        public virtual Province Province { get; set; }
        public int? ProvinceId { get; set; }
    }
}
