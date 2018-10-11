using System;
using System.Collections.Generic;

namespace RunesApp.Models
{
    public class Album
    {
        public Album()
        {
            this.Tracks = new HashSet<TrackAlbum>();
        }
        public string Id { get; set; } = new Guid().ToString();
        public string Name { get; set; }
        public string Cover { get; set; }
        public decimal Price { get; set; }
        //// => (this.Tracks.Sum(x => x.Price)) - this.Tracks.Sum(x => x.Price) * 0.13m;
        public virtual ICollection<TrackAlbum> Tracks { get; set; }
    }
}