using System.Collections.Generic;
using Imperator.Save;

namespace ImperatorStats.Models
{
    public class GameViewModel
    {
        public Game Game { get;  }
        public string Message { get;  }
        public string Title => Game != null ? Game.Name : "Error";
        public IEnumerable<Save> Saves => Game != null ? Game.Saves : new List<Save>();
        public int GameId { get; }
        public bool HasAccess => Game != null;

        public GameViewModel(Game game, int gameId, string s = null)
        {
            Game = game;
            GameId = gameId;
            Message = s;
        }
    }
}
