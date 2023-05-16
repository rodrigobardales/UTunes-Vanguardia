﻿using UTunes.Core.Entities;

namespace UTunes.Api.DTOs
{
    public class AlbumDataTransferObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Review { get; set; }
        public int Rating { get; set; }
        public double Price { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}

