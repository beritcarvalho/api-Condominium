using CondominiumApi.Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CondominiumApi.Infrastructure.Data.Repositories
{
    public class BaseRepository<T> where T : class
    {
        protected readonly DataBaseContext Context;

        public BaseRepository(DataBaseContext context) => Context = context;

        //Create
        public T Insert(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public async Task<T> InsertAsync(T entity)
        {
            Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        //Read
        public T GetById(decimal id)
        {
            var entity = Context.Set<T>().Find(id);
            return entity;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            return entity;
        }

        public List<T> GetAll() => Context.Set<T>().ToList();

        public Task<List<T>> GetAllAsync() => Context.Set<T>().ToListAsync();

        //Update
        public T Update(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        //Delete
        public void Remove(T entidade)
        {
            Context.Set<T>().Remove(entidade);
            Context.SaveChanges();
        }

        public async Task RemoveAsync(T entidade)
        {
            Context.Set<T>().Remove(entidade);
            await Context.SaveChangesAsync();
        }
    }

}
