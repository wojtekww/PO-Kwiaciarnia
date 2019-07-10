using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.ViewModels
{
    public class OrderDetailsViewModel
    {
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public string Status { get; set; }
    }
}
