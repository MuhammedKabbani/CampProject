﻿using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
	public class EFEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
		where TEntity : class, IEntity, new()
		where TContext : DbContext, new()
	{
		public void Add(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				context.SaveChanges();
			}
		}

		public void Delete(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Deleted;
				context.SaveChanges();
			}
		}

		public TEntity Get(Expression<Func<TEntity, bool>> expression)
		{
			using (TContext context = new TContext())
			{
				return context.Set<TEntity>().FirstOrDefault(expression);
			}
		}

		public List<TEntity> GetAll(Expression<Func<TEntity, bool>> expression = null)
		{
			using (TContext context = new TContext())
			{
				return expression == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(expression).ToList();
			}
		}
		public void Update(TEntity entity)
		{
			using (TContext context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Modified;
				context.SaveChanges();
			}
		}
	}
}
