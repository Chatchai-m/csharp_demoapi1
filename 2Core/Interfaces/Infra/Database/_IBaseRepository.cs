using _1Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Core.Interfaces.Infra.Database
{
    public interface _IBaseRepository<TEntity> where TEntity : _IBaseEntity
    {
        Task<TEntity> GetAsynce(object id);
        Task InsertOrUpdateAsynce(TEntity entity);
        Task DeleteAsynce(object id);
        Task<int> Count();
        IQueryable<TEntity> GetQueryable();
    }
}
