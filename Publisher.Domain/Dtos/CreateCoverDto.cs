using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Dtos
{
    public class CreateCoverDto
    {
        public string? Title { get; set; }
        public bool DigitalOnly { get; set; }
        public int BookId { get; set; }
        // Artists tilknyttes normalt efterfølgende via relationen (ArtistCover)
    }
}
