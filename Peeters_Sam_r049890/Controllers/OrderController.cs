using Microsoft.AspNetCore.Mvc;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Data.Cart;
using Peeters_Sam_r049890.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class OrderController : Controller
  {
    private readonly ShoppingCart _shoppingCart;
    private readonly ApplicationDbContext _context;
    public OrderController(ShoppingCart shoppingCart, ApplicationDbContext context)
    {
      _shoppingCart = shoppingCart;
      _context = context;
    }
    public IActionResult Index()
    {
      var items = _shoppingCart.GetShoppingCardItems();
      _shoppingCart.shoppingCardItems = items;
      var response = new ShoppingCartViewModel()
      {
        ShoppingCart = _shoppingCart,
        ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
      };
      return View(response);
    }
  }
}
