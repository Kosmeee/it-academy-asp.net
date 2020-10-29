using System;
using ItAcademy.Project.Music.Domain.Models;

namespace ItAcademy.Project.Music.Client.Models
{
    public class ViewTrack
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public DateTime AddedDate { get; set; }
    }
}