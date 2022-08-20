using Peeters_Sam_r049890.Data.Cart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.ViewModels
{
  public class ShoppingCartViewModel
  {
    public ShoppingCart ShoppingCart { get; set; }
    public Decimal ShoppingCartTotal { get; set; }
  }
}
