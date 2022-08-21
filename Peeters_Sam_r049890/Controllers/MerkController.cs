using Microsoft.AspNetCore.Authorization;
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
  [Authorize(Roles = "manager")]
  public class MerkController : Controller
  {
    private readonly ApplicationDbContext _context;
    

    public MerkController(ApplicationDbContext context)
    {
      _context = context;
    }
    
    public async Task<IActionResult> Index()
    {
      var data = await _context.Merken.ToListAsync();
      return View(data);
    }
    
    public async Task<IActionResult> Create([Bind("MerkId,Merknaam,Herkomst")] Merk merk)
    {
      if (ModelState.IsValid)
      {
        _context.Add(merk);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      CreateMerkViewModel vm = new CreateMerkViewModel()
      {
        Merknaam = merk.Merknaam,
        Herkomst = merk.Herkomst
      };
      return View(vm);
    }

    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }
      var merk = await _context.Merken.FirstOrDefaultAsync(m => m.MerkId == id);
      if (merk == null)
      {
        return NotFound();
      }
      MerkDeleteViewModel vm = new MerkDeleteViewModel()
      {
        Merknaam = merk.Merknaam,
        Herkomst = merk.Herkomst
      };
      return View(vm);

    }
    private bool MerkExists(int id)
    {
      Merk merk = _context.Merken.Find(id);
      if (merk != null)
      {
        return true;
      }
      return false;
    }
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var merk = await _context.Merken.FindAsync(id);
      _context.Merken.Remove(merk);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      Merk merk = await _context.Merken.FindAsync(id);

      if (merk == null)
      {
        return NotFound();
      }

      MerkEditViewModel vm = new MerkEditViewModel()
      {
        Merknaam = merk.Merknaam,
        Herkomst = merk.Herkomst
      };
      return View(vm);
    }
    [HttpPost]
    
    public async Task<IActionResult> Edit(int id,
                [Bind("Merknaam,Herkomst")] Merk merk)
    {
      merk.MerkId = id;
      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(merk);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!MerkExists(merk.MerkId))
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
      MerkEditViewModel vm = new MerkEditViewModel()
      {
        Merknaam = merk.Merknaam,
        Herkomst = merk.Herkomst
        
      };

      return View(vm);
    }
  }
  
}
