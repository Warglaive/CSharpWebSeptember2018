using System.Collections.Generic;
using System.Linq;

namespace RunesApp.Models
{
    public class Album
    {
        public Album()
        {
            this.Tracks = new HashSet<Track>();
        }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cover { get; set; }

        private decimal Price => this.Tracks.Sum(x => x.Price) - (this.Tracks.Sum(x => x.Price) * 0.13m);

        public ICollection<Track> Tracks { get; set; }
    }
}