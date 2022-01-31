using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ImageFile
    {
        [Key]
        public int imageId { get; set; }
        [StringLength(100)]
        public string imageName { get; set; }
        [StringLength(250)]
        public string imagePath { get; set; }
    }
}
