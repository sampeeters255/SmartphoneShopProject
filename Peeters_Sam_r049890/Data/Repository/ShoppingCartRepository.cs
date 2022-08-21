using Peeters_Sam_r049890.Data.Repository.IRepository;
using Peeters_Sam_r049890.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository
{
  public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
  {
    private ApplicationDbContext _context;
    public ShoppingCartRepository(ApplicationDbContext context) : base(context)
    {
      _context = context;
    }
  }
}
