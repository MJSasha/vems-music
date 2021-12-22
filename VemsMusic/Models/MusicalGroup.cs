using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VemsMusic.Models
{
    public class MusicalGroup
    {
        public int Id { get; set; }

        [Display(Name = "Название группы")]
        public string Name { get; set; }

        [Display(Name = "Описание группы")]
        public string Description { get; set; }

        [Display(Name = "Путь к картинке")]
        public string Picture { get; set; }



        [Display(Name = "Id жанра")]
        public int? GenreId { get; set; }
        public List<Genre> Genres { get; set; } = new();
        public List<Music> Musics { get; set; } = new();
    }
}
