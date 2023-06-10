using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFresh_API.Models
{
    public class ProductStock
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Instock { get; set; }

        public virtual Product Product { get; set; }
        public virtual Unit Unit { get; set; }
    }
}
