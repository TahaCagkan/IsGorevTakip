using IsGorevTakip.Core.DAL;
using IsGorevTakip.Core.Enitiy.Abstract;
using IsGorevTakip.DAL.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsGorevTakip.DAL.Concrete
{
    public class EfGenericRepository<TEntity, TContext> : IGenericRepository<TEntity>
                 where TEntity : class, IBaseEntity, new()
                 where TContext : DbContext
    {
        private readonly TContext _context;

        public EfGenericRepository(TContext context)
        {
            this._context = context;
        }

        public List<TEntity> GetAll()
        {
            using var context = new IsGorevTakipContext();
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetId(int id)
        {
            using var context = new IsGorevTakipContext();
            return context.Set<TEntity>().Find(id);
        }


        public void Save(TEntity entity)
        {
            using var context = new IsGorevTakipContext();
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            using var context = new IsGorevTakipContext();
            context.Set<TEntity>().Update(entity);
            context.SaveChanges();
        }
        public void Delete(TEntity entity)
        {
            using var context = new IsGorevTakipContext();
            context.Set<TEntity>().Remove(entity);
            context.SaveChanges();
        }
    }
}
