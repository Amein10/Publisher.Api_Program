using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Models
{
    // Repræsenterer en kunstner i systemet
    public class Artist
    {
        // Unik ID for kunstneren (primær nøgle)
        public int ArtistId { get; set; }

        // Kunstnerens fornavn (kan være tom)
        public string? FirstName { get; set; }

        // Kunstnerens efternavn (kan være tom)
        public string? LastName { get; set; }

        // Liste over alle covers, kunstneren er forbundet til
        public List<ArtistCover> ArtistCovers { get; set; } = new();
    }
}
