using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class StatsViewModel
    {
        public Save Save { get;  }
        public StatsViewModel(Save save)
        {
            Save = save;
        }
    }
}
