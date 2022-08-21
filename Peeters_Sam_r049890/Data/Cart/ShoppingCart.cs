using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Cart
{
  public class ShoppingCart
  {
    public ApplicationDbContext _context { get; set; }
    public string ShoppingCartId { get; set; }
    public List<ShoppingCardItem> shoppingCardItems { get; set; }

    public ShoppingCart(ApplicationDbContext context)
    {
      _context = context;
    }

   

    public void AddSmartphoneToCart(Smartphone smartphone)
    {
      var shoppingCartItem = _context.ShoppingCardItems.FirstOrDefault(s => s.Smartphone.SmartphoneId == smartphone.SmartphoneId && s.ShoppingCardId == ShoppingCartId);
      if (shoppingCartItem == null)
      {
        shoppingCartItem = new ShoppingCardItem()
        {
          ShoppingCardId = ShoppingCartId,
          Smartphone = smartphone,
          Hoeveelheid = 1
        };
        _context.ShoppingCardItems.Add(shoppingCartItem);
      }
      else
      {
        shoppingCartItem.Hoeveelheid++;
      }
      _context.SaveChanges();
    }
    public void RemoveItemFromCart(Smartphone smartphone)
    {
      var shoppingCartItem = _context.ShoppingCardItems.FirstOrDefault(s => s.Smartphone.SmartphoneId == smartphone.SmartphoneId && s.ShoppingCardId == ShoppingCartId);
      if (shoppingCartItem != null)
      {
        if (shoppingCartItem.Hoeveelheid > 1)
        {
          shoppingCartItem.Hoeveelheid--;
        }
               
      }
      else
      {
        shoppingCartItem.Hoeveelheid++;
      }
      
      _context.SaveChanges();
    }

    public List<ShoppingCardItem> GetShoppingCardItems()
    {
      return shoppingCardItems ?? (shoppingCardItems = _context.ShoppingCardItems.Where(s => s.ShoppingCardId == ShoppingCartId).Include(s => s.Smartphone).ToList());
    }

    public Decimal GetShoppingCartTotal()
    {
      var total = _context.ShoppingCardItems.Where(s => s.ShoppingCardId == ShoppingCartId).Select(s => s.Smartphone.Prijs * s.Hoeveelheid).Sum();
      return total;
    }
  }
}
