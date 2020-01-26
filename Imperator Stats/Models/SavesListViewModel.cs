using System;
using System.Collections;
using System.Collections.Generic;
using ImperatorSaveParser;

namespace ImperatorStats.Models
{
    public class SavesListViewModel
    {
        public IList<Save> Saves { get;  }

        public SavesListViewModel(IList<Save> saves)
        {
            Saves = saves;
        }
    }
}
