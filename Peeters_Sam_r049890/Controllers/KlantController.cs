using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
  public class KlantController : Controller
  {

    private readonly ApplicationDbContext _context;

    public KlantController(ApplicationDbContext context)
    {
      _context = context;
    }
    public async Task<IActionResult> Index()
    {
      var data = await _context.Klanten.ToListAsync();
      return View();
    }
  }
}
