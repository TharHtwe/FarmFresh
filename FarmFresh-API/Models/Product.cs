using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FarmFresh_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        //[ForeignKey("Category")]
        public int CategoryId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Images { get; set; }
        public string CountryOfOrigin { get; set; }
        public bool NewArrival { get; set; }

        //For demostration purpose only
        //Should retrieve from promotion rules
        public bool OnPromotion { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductStock> Stocks { get; set; }

        public object this[string propertyName]
        {
            get
            {
                // probably faster without reflection:
                // like:  return Properties.Settings.Default.PropertyValues[propertyName] 
                // instead of the following
                Type myType = typeof(Product);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                return myPropInfo.GetValue(this, null);
            }
            set
            {
                Type myType = typeof(Product);
                PropertyInfo myPropInfo = myType.GetProperty(propertyName);
                myPropInfo.SetValue(this, value, null);
            }
        }
    }
}
