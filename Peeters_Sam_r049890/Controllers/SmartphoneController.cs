using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class SmartphoneController : Controller
  {
    private readonly ApplicationDbContext _context;

    public SmartphoneController(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      var data = await _context.Smartphones.ToListAsync();
      return View(data);
    }
  }
}
