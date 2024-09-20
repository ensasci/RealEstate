using Microsoft.EntityFrameworkCore;
using RealEstate.Services.EntityFramework.Context;
using RealEstate.Services.EntityFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate.Services.Repository.Entity
{
	public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
	{
		private readonly RealEstateContext _context;

		public GenericRepository(RealEstateContext context)
		{
			_context = context;
		}
		public async Task<bool> Create(TEntity entity)
		{
			try
			{
				await _context.Set<TEntity>().AddAsync(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public async Task<bool> Delete(int id)
		{

			try
			{
				var entity = await GetById(id);
				_context.Set<TEntity>().Remove(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
		{
			return filter == null
				? _context.Set<TEntity>().ToList()
				: _context.Set<TEntity>().Where(filter).ToList();
		}

		public List<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] includes)
		{

			IQueryable<TEntity> query = _context.Set<TEntity>();

			if (filter != null)
			{
				query = query.Where(filter);
			}
			if (includes != null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			return query.ToList();
		}

		public List<TEntity> GetAllSingleInclude(Expression<Func<TEntity, object>> include, Expression<Func<TEntity, bool>> filter = null)
		{
			IQueryable<TEntity> query = _context.Set<TEntity>().Include(include);

			if (filter != null)
			{
				query = query.Where(filter);
			}

			return query.ToList();
		}

		public async Task<TEntity> GetById(int id)
		{
			try
			{
				return _context.Set<TEntity>().AsNoTracking().FirstOrDefault(x => x.Id == id);
			}
			catch (Exception)
			{

				throw;
			}

		}

		public async Task<bool> Update(int id, TEntity entity)
		{
			try
			{
				_context.Set<TEntity>().Update(entity);
				await _context.SaveChangesAsync();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}
	}
}
