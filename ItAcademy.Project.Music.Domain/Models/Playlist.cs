using System.Collections.Generic;

namespace ItAcademy.Project.Music.Domain.Models
{
    public class Playlist
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public List<Track> Tracks { get; set; }
    }
}
