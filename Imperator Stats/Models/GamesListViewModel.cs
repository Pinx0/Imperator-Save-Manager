using System.Collections.Generic;
using Imperator.Save;

namespace ImperatorStats.Models
{
    public class GamesListViewModel
    {
        public IList<Game> Games { get;  }
        public string Message { get;  }

        public GamesListViewModel(IList<Game> games, string s = null)
        {
            Games = games;
            Message = s;
        }
    }
}
