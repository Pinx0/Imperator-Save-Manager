using System.Collections.Generic;

namespace Imperator.Save
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Save> Saves { get; set; } = new List<Save>();


    }
}