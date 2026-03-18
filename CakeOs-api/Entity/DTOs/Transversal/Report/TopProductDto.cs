using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeOs.Entity.DTOs.Transversal.Report
{
    public class TopProductDto
    {
        public string ProductName { get; set; }
        public string TypeName { get; set; }
        public string SizeName { get; set; }
        public string ShapeName { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalRevenue { get; set; }
    }
}
