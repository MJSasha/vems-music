using System.Collections.Generic;
using VemsMusic.Models;

namespace VemsMusic.Other_Data.ViewModels
{
    public class GroupWithMusicsViewModel
    {
        public MusicalGroup MusicalGroup { get; set; }
        public IEnumerable<Music> GetAllMusic { get; set; }
    }
}
