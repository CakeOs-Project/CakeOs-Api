using CakeOS.Entity.Domain.Base;

namespace CakeOs.Entity.Domain.Parameter
{
    public class Image : BaseDomain
    {
        public string Url { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long Size { get; set; }

    }
}
