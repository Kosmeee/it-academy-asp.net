using System;
using System.Collections.Generic;

namespace ItAcademy.Project.Music.Domain.Models
{
    public class Album
    {
        public int Id { get; set; }

        public Artist Artist { get; set; }

        public List<Track> Tracks { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
