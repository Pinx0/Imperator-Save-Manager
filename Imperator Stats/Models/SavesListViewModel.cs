using System.Collections.Generic;
using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class SavesListViewModel
    {
        public IList<Save> Saves { get;  }
        public string Message { get;  }

        public SavesListViewModel(IList<Save> saves, string s = null)
        {
            Saves = saves;
            Message = s;
        }
    }
}
