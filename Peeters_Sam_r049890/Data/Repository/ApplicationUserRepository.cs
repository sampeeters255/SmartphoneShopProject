using Peeters_Sam_r049890.Data.Repository.IRepository;
using Peeters_Sam_r049890.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository
{
  public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepositoy
  {
    private ApplicationDbContext _context;
    public ApplicationUserRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
  }
}
