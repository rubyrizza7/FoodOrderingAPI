using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FoodOrderingApi.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
        public double TotalPrice { get; set; }
        internal virtual Order Order { get; set; }

        // Navigation
        public virtual List<Selection> Selections { get; set; }

    }
}
