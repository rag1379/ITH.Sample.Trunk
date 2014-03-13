using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace POUM.Entity
{
    public class Movie
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }

        [Required,MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int MovieTypeId { get; set; }

        //[ForeignKey("MovieTypeId")]
        //public virtual MovieType MovieType { get; set; }

        [Required]
        public bool Active { get; set; }

        
        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }


        //public virtual List<Review> Reviews { get; set; }        
    }
}
