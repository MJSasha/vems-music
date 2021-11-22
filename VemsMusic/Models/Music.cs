namespace VemsMusic.Models
{
    public class Music
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string ImagePath { get; set; }
        public string AudioPath { get; set; }
        public int GroupId { get; set; }
    }
}
