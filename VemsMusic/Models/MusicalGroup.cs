namespace VemsMusic.Models
{
    public class MusicalGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public int GenreId { get; set; }
    }
}
