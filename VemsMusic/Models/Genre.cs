using System.ComponentModel.DataAnnotations;

namespace VemsMusic.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Display(Name = "Название жанра")]
        public string Name { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }

        [Display(Name = "Путь к картинке")]
        public string PicturePath { get; set; }
    }
}
