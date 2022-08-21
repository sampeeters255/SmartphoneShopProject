using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Peeters_Sam_r049890.Areas.Identity.Data;
using Peeters_Sam_r049890.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class GebruikerController : Controller
  {
    private UserManager<CustomUser> _userManager;

    public GebruikerController(UserManager<CustomUser> userManager)
    {
      _userManager = userManager;
    }
    public IActionResult Index()
    {
      GebruikerListViewModel vm = new GebruikerListViewModel()
      {
        Gebruikers = _userManager.Users.ToList()
      };
      return View(vm);
    }
    [Authorize(Roles = "manager")]
    public IActionResult Details(string id)
    {
      CustomUser gebruiker = _userManager.Users.Where(g => g.Id == id).FirstOrDefault();
      if (id == null)
      {
        return NotFound();
      }     

      if (gebruiker != null)
      {
        GebruikerDetailViewModel vm = new GebruikerDetailViewModel()
        {
          Id = gebruiker.Id,
          Naam = gebruiker.Naam,
          Voornaam = gebruiker.Voornaam,
          UserName = gebruiker.UserName
        };
        return View(vm);
      }
      else
      {
        GebruikerListViewModel vm = new GebruikerListViewModel()
        {
          Gebruikers = _userManager.Users.ToList()
        };
        return View("Index", vm);
      };
      
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> Create(CreateGebruikerViewModel viewModel)
    {
      if (ModelState.IsValid)
      {
        CustomUser gebruiker = new CustomUser()
        {
          Naam = viewModel.Naam,
          Voornaam = viewModel.Voornaam,
          Email = viewModel.Email,
          UserName = viewModel.Email
        };
        IdentityResult result = await _userManager.CreateAsync(gebruiker, viewModel.Password);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach (IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
        }
      }


      return View(viewModel);
    }

    [HttpPost]
    [Authorize(Roles = "Manager")]
    public async Task<IActionResult> Delete(string id)
    {
      CustomUser user = await _userManager.FindByIdAsync(id);
      if (user != null)
      {
        IdentityResult result = await _userManager.DeleteAsync(user);
        if (result.Succeeded)
        {
          return RedirectToAction("Index");
        }
        else
        {
          foreach(IdentityError error in result.Errors)
          {
            ModelState.AddModelError("", error.Description);
          }
        }
      }
      else
      {
        ModelState.AddModelError("", "Gebruiker niet gevonden");
      }
      return View("Index", _userManager.Users.ToList());
    }

  }
}
