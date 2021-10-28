using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class Selection
    {
        // Primary Key
        [Key, ForeignKey("MenuItem")]
        public int MenuItemId { get; set; }
        [Key, ForeignKey("Cart")]
        public int CartId { get; set; }


        // Other Attributes
        public int Quantity { get; set; }
        public double SelectionPrice { get; set; }

        // navigational
        public virtual MenuItem MenuItem { get; set; }

        internal int UpdateQty(int newQty)
        {
            // update value
            Quantity = newQty;
            // update price 
            SelectionPrice = Quantity * MenuItem.Price;

            // return new quantity
            return Quantity;
        }
    }

    public class SelectionDTO
    {
        public int MenuItemId { get; set; }
        public int CartId { get; set; }
        public int Quantity { get; set; }
    }
}
