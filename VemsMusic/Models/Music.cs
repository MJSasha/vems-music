using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VemsMusic.Models
{
    public class Music
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Название трека")]
        public string Name { get; set; }

        [Display(Name = "Текст песни")]
        public string Text { get; set; }

        [Display(Name = "Путь к картинке")]
        public string ImagePath { get; set; }

        [Display(Name = "Путь к звуковому файлу")]
        public string AudioPath { get; set; }

        public string AdditionDateAndTime { get; set; }


        [Display(Name = "Id группы")]
        public int? GroupId { get; set; }
        public MusicalGroup Group { get; set; }

        [Display(Name = "Id жанра")]
        public int? GenreId { get; set; }
        public List<Genre> Genres { get; set; } = new();

        public int? UserId { get; set; }
        public List<User> Users { get; set; } = new();
    }
}
