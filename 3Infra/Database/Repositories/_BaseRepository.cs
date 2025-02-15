using _2Core.Interfaces.Infra.Database;
using _1Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3Infra.Database.Repositories
{
    public class _BaseRepository<TEntity> : _IBaseRepository<TEntity> where TEntity : _BaseEntity
    {
        protected readonly DataContext _context;

        public _BaseRepository(DataContext context)
        {
            this._context = context;
        }

        public async Task<int> Count()
        {
            return _context.Set<TEntity>().Count();
        }

        public async Task DeleteAsynce(object id)
        {
            var entity = await GetAsynce(id);
            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _context.Set<TEntity>().Attach(entity);
                }
                _context.Set<TEntity>().Remove(entity);
            }
        }


        public async Task<TEntity> GetAsynce(object id)
        {
            //return await _context.Set<TEntity>().FindAsync(id);
            return await _context.Set<TEntity>().FindAsync(id);

        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }


        public async Task InsertOrUpdateAsynce(TEntity entity)
        {
            var entityEntry = _context.Entry(entity);
            var primaryKeyName = entityEntry.Context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.Select(x => x.Name).Single();

            var primaryKeyField = entity.GetType().GetProperty(primaryKeyName);
            var t = typeof(TEntity);
            if (primaryKeyField == null)
            {
                throw new Exception($"{t.FullName} does not have a primary key specified. Unable to exec InsertOrUpdate call.");
            }


            var keyVal = primaryKeyField.GetValue(entity);
            var dbVal = _context.Set<TEntity>().Find(keyVal);

            if (dbVal != null)
            {
                _context.Entry(dbVal).CurrentValues.SetValues(entity);
                _context.Set<TEntity>().Update(dbVal);
            }
            else
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }

            await _context.SaveChangesAsync();
        }
    }
}
