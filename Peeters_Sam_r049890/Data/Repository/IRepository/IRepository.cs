using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository.IRepository
{
  public interface IRepository<T> where T : class
  {
    IEnumerable<T> GetAll();
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entity);
    T GetFirstOrDefault(Expression<Func<T, bool >> filter);
  }
}
