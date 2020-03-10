using System;
using System.Collections.Generic;

namespace northwind_mvc_i.Library.Models
{
    public partial class OrderSubtotals
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
