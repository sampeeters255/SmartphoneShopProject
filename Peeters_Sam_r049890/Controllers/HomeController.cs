using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Peeters_Sam_r049890.Data;
using Peeters_Sam_r049890.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

    
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
      _context = context;
    }

    public async Task<IActionResult> Index()
    {
      var data = await _context.Smartphones.ToListAsync();
      return View(data);
    }

    

        
    }
}
