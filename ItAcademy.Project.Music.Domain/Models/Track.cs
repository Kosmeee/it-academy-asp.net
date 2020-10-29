﻿using System;
using System.Collections.Generic;

namespace ItAcademy.Project.Music.Domain.Models
{
   public class Track
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Artist Artist { get; set; }

        public Album Album { get; set; }

        public Genre Genre { get; set; }

        public List<Playlist> Playlists { get; set; }

        public string Url { get; set; }

        public string Image { get; set; }

        public DateTime AddedDate { get; set; }
    }
}
