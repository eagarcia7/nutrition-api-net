using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FoodNutrition.Data;


namespace FoodNutrition.Models.Repositories
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
  {
    protected readonly FoodNutritionDBContext Context;

    public Repository(FoodNutritionDBContext context)
    {
      Context = context;
    }

    public TEntity Get(int id)
    {
      return Context.Set<TEntity>().Find(id);
    }

    public IEnumerable<TEntity> GetAll()
    {
      return Context.Set<TEntity>().ToList();
    }

    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
      return Context.Set<TEntity>().Where(predicate);
    }

    public void Add(TEntity entity)
    {
      Context.Set<TEntity>().Add(entity);
      Context.SaveChanges();
    }
  }
}
