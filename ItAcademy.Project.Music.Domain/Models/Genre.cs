using System.Collections.Generic;


namespace ItAcademy.Project.Music.Domain.Models
{
   public class Genre
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Track> Tracks { get; set; }
        public List<Artist> Artists { get; set; }
        public string Image { get; set; }
    }
}
