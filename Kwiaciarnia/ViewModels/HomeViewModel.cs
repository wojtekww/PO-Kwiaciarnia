using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.ViewModels
{
    public class HomeViewModel
    {
        public string Title { get; set; }
        public List<Product> Products { get; set; }
    }
}
