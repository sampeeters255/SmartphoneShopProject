using Peeters_Sam_r049890.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository
{
  public class UnitOfWork : IUnitOfWork
  {
    private ApplicationDbContext _context;
    public UnitOfWork(ApplicationDbContext context)
    {
      _context = context;
      ShoppingCart = new ShoppingCartRepository(_context);
      ApplicationUser = new ApplicationUserRepository(_context);
    }

    public IShoppingCartRepository ShoppingCart { get; }

    public IApplicationUserRepositoy ApplicationUser { get; }
    public void Save()
    {
      _context.SaveChanges();
    }
  }
}
