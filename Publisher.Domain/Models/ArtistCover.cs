using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Publisher.Domain.Models
{
    public class ArtistCover
    {
        public int ArtistId { get; set; }
        public Artist? Artist { get; set; }

        public int CoverId { get; set; }
        public Cover? Cover { get; set; }
    }

}
