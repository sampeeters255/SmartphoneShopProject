using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository.IRepository
{
  public interface IUnitOfWork
  {
    IShoppingCartRepository ShoppingCart { get; }
    IApplicationUserRepositoy ApplicationUser { get; }
    void Save();
  }
}
