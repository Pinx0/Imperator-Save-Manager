using System.Collections.Generic;

namespace Imperator.Save
{
    public class Game
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string PasswordHash { get; set; }
        public ICollection<Save> Saves { get; set; } = new List<Save>();
        private bool IsPublic => PasswordHash == null;
        public string IsPublicString => IsPublic ? "Yes" : "No";
    }
}