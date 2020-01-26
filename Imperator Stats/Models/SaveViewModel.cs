using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class SaveViewModel
    {
        public Save Save { get;  }

        public SaveViewModel(Save save)
        {
            Save = save;
        }
    }
}
