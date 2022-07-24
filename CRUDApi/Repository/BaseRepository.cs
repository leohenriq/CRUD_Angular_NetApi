using CRUDApi.Interface;
using CRUDApi.Context;
using CRUDApi.Model;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace CRUDApi.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        #region Fields

        protected CRUDContext Context;

        #endregion Fields

        #region Constructor

        public BaseRepository(CRUDContext context)
        {
            Context = context;
        }

        #endregion Constructor

        #region Public Methods
        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetById(long id)
        {
            return await Context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Add(T entity)
        {
            entity.Status = true;

            await Context.Set<T>().AddAsync(entity);
            await Context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task Update(T entity)
        {
            var existing = await Context.Set<T>().FindAsync(entity.Id);
            if (existing == null)
                return;

            Context.Entry(existing).CurrentValues.SetValues(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task StatusEnable(long id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity == null)
                return;

            entity.Status = true;
            await Update(entity);
        }
        public virtual async Task StatusDisable(long id)
        {
            var entity = await Context.Set<T>().FindAsync(id);
            if (entity == null)
                return;

            entity.Status = false;
            await Update(entity);
        }

        public async Task Delete(T entity)
        {
            var existing = await Context.Set<T>().FindAsync(entity.Id);
            if (existing == null)
                return;

            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        #endregion Public Methods

        #region Dispose

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Context.Dispose();
            }
        }


        #endregion Dispose
    }
}