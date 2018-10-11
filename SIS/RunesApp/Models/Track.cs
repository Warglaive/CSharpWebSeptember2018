using System;
using System.Collections.Generic;

namespace RunesApp.Models
{
    public class Track
    {
        public Track()
        {
            this.Albums = new HashSet<TrackAlbum>();
        }
        public string Id { get; set; } = new Guid().ToString();
        public string Name { get; set; }
        public string Link { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<TrackAlbum> Albums { get; set; }
    }
}