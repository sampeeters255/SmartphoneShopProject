using Microsoft.EntityFrameworkCore;
using Peeters_Sam_r049890.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Peeters_Sam_r049890.Data.Repository
{
  public class Repository<T> : IRepository<T> where T : class
  {
    private readonly ApplicationDbContext _context;
    internal DbSet<T> dbset;
    public Repository(ApplicationDbContext context)
    {
      _context = context;
      this.dbset = _context.Set<T>();
    }
    public void Add(T entity)
    {
      dbset.Add(entity);
    }

    public IEnumerable<T> GetAll()
    {
      IQueryable<T> query = dbset;
      return query.ToList();
    }

    public T GetFirstOrDefault(Expression<Func<T, bool>> filter)
    {
      IQueryable<T> query = dbset;
      query = query.Where(filter);
      return query.FirstOrDefault();
    }

    public void Remove(T entity)
    {
      dbset.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entity)
    {
      dbset.RemoveRange(entity);
    }
  }
}
