using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kwiaciarnia.Models;

namespace Kwiaciarnia.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public decimal ShoppingCartTotal { get; set; }
        public int ProductsInCart()
        {
            int pic=0;
            foreach(ShoppingCartItem sci in ShoppingCart.GetShoppingCartItems())
            {
                pic += sci.Amount;
            }
            return pic;
        }
    }
}
