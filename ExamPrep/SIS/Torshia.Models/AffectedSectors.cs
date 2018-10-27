using Torshia.Models.Enums;

namespace Torshia.Models
{
    public class AffectedSectors
    {
        public int Id { get; set; }

        public Task Task { get; set; }

        public int TaskId { get; set; }

        public Sectors Affected { get; set; }
    }
}