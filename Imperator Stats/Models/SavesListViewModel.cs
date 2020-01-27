using System.Collections.Generic;
using Imperator.Save;

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
