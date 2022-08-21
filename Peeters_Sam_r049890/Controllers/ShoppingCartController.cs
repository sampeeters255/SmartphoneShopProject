using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Data.Repository.IRepository;
using Peeters_Sam_r049890.Models;
using Peeters_Sam_r049890.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class ShoppingCartController : Controller
  {
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;
    public ShoppingCartController(ShoppingCart shoppingCart, ApplicationDbContext context)
    {
            _context = context;
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public IActionResult Index(ShoppingCart shoppingCart)
    {
      var claimIdentity = (ClaimsIdentity)User.Identity;
      var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
      shoppingCart.UserId = claim.Value;
      ShoppingCart cart = _unitOfWork.ShoppingCart.GetFirstOrDefault(c => c.UserId == claim.Value && c.SmartphoneId == shoppingCart.SmartphoneId);
      if (cart == null)
      {
        _unitOfWork.ShoppingCart.Add(shoppingCart);
      }
      else
      {
        _unitOfWork.ShoppingCart.AddSmartphone(cart, shoppingCart.Hoeveelheid);
      }
      _unitOfWork.Save();

      return RedirectToAction("Index", "Home");
    }
  }
}
