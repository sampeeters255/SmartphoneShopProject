using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Models;
using Peeters_Sam_r049890.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class SmartphoneController : Controller
  {
    public List<Smartphone> smartphones;
    private readonly ApplicationDbContext _context;

    public SmartphoneController(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      SmartphoneListViewModel vm = new SmartphoneListViewModel();
      vm.Smartphones = await _context.Smartphones.ToListAsync();
      return View(vm);
    }

    public IActionResult Create()
    {
      return View();
    }
    public async Task<IActionResult> Create([Bind("SmartphoneId,AangemaaktDatum,Prijs, Model,MerkId")]Smartphone smartphone)
    {
      if (ModelState.IsValid)
      {
        _context.Add(smartphone);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      SmartphoneCreateViewModel vm = new SmartphoneCreateViewModel()
      {
        Model = smartphone.Model,
        Prijs = smartphone.Prijs,

        
      };
      return View(vm);
    }

    public async Task<IActionResult> Details(int id)
    {
      Smartphone smartphone = await _context.Smartphones.FindAsync(id);
      if (smartphone == null)
      {
        return NotFound();
      }

      DetailsSmartphoneViewModel vm = new DetailsSmartphoneViewModel()
      {
        Model = smartphone.Model,
        Prijs = smartphone.Prijs,
        Merk = smartphone.Merk
      };
      return View(vm);
    }
  }
}
