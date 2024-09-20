using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Repository.Entity
{
    public interface IRepository<TEntity> where TEntity: class
    {
        Task<bool> Create(TEntity entity);
        Task<bool> Update(int id,TEntity entity);
        Task<bool> Delete(int id);
		List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
		Task<TEntity> GetById(int id);
        List<TEntity> GetAllSingleInclude(Expression<Func<TEntity, object>> include, Expression<Func<TEntity, bool>> filter = null);

		List<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes);

	}
}
