using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class Order
    {
        
        [Key]
        public int OrderId { get; set; }
        
        [Required, ForeignKey("Cart")]
        public int CartId { get; set; }
        public virtual Cart Cart { get; set; }


        // Other Attributes
        public DateTime TimePlaced { get; set; }
    }
}
