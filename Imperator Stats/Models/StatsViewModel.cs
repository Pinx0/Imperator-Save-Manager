using System;
using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class StatsViewModel
    {
        public Save Save { get;  }

        public DateTime Fecha
        {
            get
            {
                if (Save != null)
                    return Save.Date;
                return DateTime.Today;
            }
        }

        public StatsViewModel(Save save)
        {
            Save = save;
        }
    }
}
