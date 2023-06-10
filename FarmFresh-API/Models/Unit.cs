using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FarmFresh_API.Models
{
    public class Unit
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductStock> Stocks { get; set; }
    }
}
