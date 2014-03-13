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
    public class ImageDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { set; get; }

        [Required, StringLength(10)]
        public string ClientNumber { set; get; }
        
        [Required]
        public byte[] FullImage { set; get; }

        public string ImageType { set; get; }
    }
}
