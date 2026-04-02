using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Parameter.Image
{
    public class ImageUpdateDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }
        public bool IsActive { get; set; }
    }
}
