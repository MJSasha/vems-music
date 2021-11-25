using System.Collections.Generic;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.ViewModels
{
    public class AllMusicAndAllGroupAndAllGenreViewModel
    {
        public IEnumerable<Music> AllMusic { get; set; }
        public IEnumerable<Genre> AllGenre { get; set; }
        public IEnumerable<MusicalGroup> AllGroup { get; set; }
    }
}
