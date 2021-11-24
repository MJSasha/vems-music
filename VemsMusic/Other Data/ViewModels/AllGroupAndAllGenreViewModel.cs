using System.Collections.Generic;

namespace VemsMusic.Models.ViewModels
{
    public class AllGroupAndAllGenreViewModel
    {
        public IEnumerable<MusicalGroup> AllGroups { get; set; }
        public IEnumerable<Genre> AllGenres { get; set; }
    }
}
