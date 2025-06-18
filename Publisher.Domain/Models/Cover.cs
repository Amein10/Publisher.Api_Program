using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Models
{
    // Repræsenterer et cover til en bog
    public class Cover
    {
        // Unik ID for coveret (primær nøgle)
        public int CoverId { get; set; }

        // Titel på coveret (kan være tom)
        public string? Title { get; set; }

        // True hvis coveret kun findes digitalt
        public bool DigitalOnly { get; set; }

        // ID for den bog coveret tilhører (foreign key)
        public int BookId { get; set; }

        // Liste over alle kunstnere, der har arbejdet på coveret (mange-til-mange)
        public List<ArtistCover> ArtistCovers { get; set; } = new();

        // Reference til den tilhørende bog (navigation property)
        public Book? Book { get; set; }
    }
}
