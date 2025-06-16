using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Models
{
    public class Cover
    {
        public int CoverId { get; set; }
        public string? Title { get; set; }
        public bool DigitalOnly { get; set; }

        public int BookId { get; set; }
        public List<ArtistCover> ArtistLinks { get; set; } = new();
        public Book? Book { get; set; }
        
    }
}