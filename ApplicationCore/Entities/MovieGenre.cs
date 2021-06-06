using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entities
{
    [Table("MovieGenre")]
    public class MovieGenre
    {
        [Key, Column(Order = 1)]
        public int MovieId { get; set; }

        [Key, Column(Order = 1)]
        public int GenreId { get; set; }

        public Movie Movie { get; set; }

        public Genre Genre { get; set; }
    }
}