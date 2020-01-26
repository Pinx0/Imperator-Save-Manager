using Pdoxcl2Sharp;
using System;
using System.Collections.Generic;

namespace ImperatorSaveParser
{
    public class Save : IParadoxRead
    {
        public int SaveId { get; set; }
        public string SaveKey { get; set; }
        public ICollection<Family> Families { get; private set; } = new List<Family>();
        public ICollection<Country> Countries { get; private set; } = new List<Country>();
        public DateTime Date { get; private set; }

        public void TokenCallback(ParadoxParser parser, string token)
        {
            if (token.StartsWith("SAV") && SaveKey == null)
            {
                SaveKey = token;
            }
            switch (token)
            {
                case "save_game_version":
                    parser.ReadString();
                    break;
                case "version":
                    parser.ReadString();
                    break;
                case "date":
                    Date = parser.ReadDateTime();
                    break;
                case "meta_player_name":
                    parser.ReadString();
                    break;
                case "enabled_dlcs":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "play_time":
                    parser.ReadString();
                    break;
                case "enabled_mods":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "speed":
                    parser.ReadString();
                    break;
                case "random_seed":
                    parser.ReadString();
                    break;
                case "random_count":
                    parser.ReadString();
                    break;
                case "game_configuration":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "variables":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "family":
                    parser.Parse(new FamilyManager(this));
                    break;
                case "character":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "objectives":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "strike_team":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "armies":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "country":
                    parser.Parse(new CountryManager(this));
                    break;
                case "state":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "horde":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "mercenary":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "population":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "provinces":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "road_network":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "revolt":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "combat":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "trade":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "diplomacy":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "jobs":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "dynamic_game_object_manager":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "cancellable_modifiers_manager":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "ironman_manager":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "mission_manager":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "playthrough_id":
                    parser.ReadString();
                    break;
                case "tutorial_disable":
                    parser.ReadString();
                    break;
                case "turn":
                    parser.ReadString();
                    break;
                case "ai_tasks":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "replay":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "ai_combat":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "ai_war":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "triggered_event":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "next_player_event_id":
                    parser.ReadString();
                    break;
                case "player_event":
                    parser.Parse(new IgnoredEntity());
                    break;
                case "played_country":
                    parser.Parse(new IgnoredEntity());
                    break;
            }
        }

    }
}
