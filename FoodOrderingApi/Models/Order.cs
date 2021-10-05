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
        // Primary Key & Navigational
        [Key, ForeignKey("Cart")]
        public int CartId { get; set; }
        public Cart Cart { get; set; }


        // Other Attributes
        public DateTime TimePlaced { get; set; }
    }
}
