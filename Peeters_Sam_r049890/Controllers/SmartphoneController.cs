using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Data.Repository.IRepository;
using Peeters_Sam_r049890.Models;
using Peeters_Sam_r049890.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class SmartphoneController : Controller
  {
    public List<Smartphone> smartphones;
    private readonly ApplicationDbContext _context;
    private readonly IWebHostEnvironment _webHostEnvironment;
    

    public SmartphoneController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
    {
      _context = context;
      _webHostEnvironment = webHostEnvironment;
    }
    public async Task<IActionResult> Index()
    {
      SmartphoneListViewModel vm = new SmartphoneListViewModel();
      vm.Smartphones = await _context.Smartphones.ToListAsync();
      return View(vm);
    }
    [Authorize(Roles = "manager")]
    public async Task<IActionResult> Create([Bind("SmartphoneId,Prijs,Model,Merk,ImageFile")] Smartphone smartphone)
    {
      if (ModelState.IsValid)
      {
        //afbeelding opslaan in wwwroot/Image
        string imgFolder = "images";
        imgFolder += Guid.NewGuid().ToString() + "_" + smartphone.ImageFile.FileName;
        smartphone.ImageUrl = "/" + imgFolder;
        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, imgFolder);

        await smartphone.ImageFile.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
              
       
        _context.Add(smartphone);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
        CreateSmartphoneViewModel vm = new CreateSmartphoneViewModel()
        {
          Merk = smartphone.Merk,
          Prijs = smartphone.Prijs,
          Model = smartphone.Model,
          ImageFile = smartphone.ImageFile,
          ImageName = smartphone.ImageName,
          AangemaaktDatum = smartphone.AangemaaktDatum
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
        Merk = smartphone.Merk,
        ImageUrl = smartphone.ImageUrl,
        SmartphoneId = smartphone.SmartphoneId
      };
      return View(vm);
    }

   
    

    [Authorize(Roles = "manager")]
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var smartphone = await _context.Smartphones.FirstOrDefaultAsync(m => m.SmartphoneId == id);
      if (smartphone == null)
      {
        return NotFound();
      }
      DetailsSmartphoneViewModel vm = new DetailsSmartphoneViewModel()
      {
        Model = smartphone.Model,
        Prijs = smartphone.Prijs,
        Merk = smartphone.Merk,
        ImageUrl = smartphone.ImageUrl,
        SmartphoneId = smartphone.SmartphoneId
      };
      return View(vm);
      
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var smartphone = await _context.Smartphones.FindAsync(id);
      _context.Smartphones.Remove(smartphone);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Smartphone sm = await _context.Smartphones.FindAsync(id);

      if (sm == null)
      {
        return NotFound();
      }

      DetailsSmartphoneViewModel vm = new DetailsSmartphoneViewModel()
      {
        Merk = sm.Merk,
        Model = sm.Model,
        Prijs = sm.Prijs,

      };
      return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id,
                 [Bind("Merk,Model,Prijs")] Smartphone smartphone)
    {
      smartphone.SmartphoneId = id;
      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(smartphone);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PhoneExists(smartphone.SmartphoneId))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      DetailsSmartphoneViewModel vm = new DetailsSmartphoneViewModel()
      {
        Merk = smartphone.Merk,
        Model = smartphone.Model,
        Prijs = smartphone.Prijs
      };

      return View(vm);
    }
    private bool PhoneExists(int id)
    {
      Smartphone smartphone = _context.Smartphones.Find(id);
      if (smartphone != null)
      {
        return true;
      }
      return false;
    }
  }
}
