using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        // Liste med forbindelser til covers
        public List<ArtistCover> ArtistLinks { get; set; } = new();
    }
}