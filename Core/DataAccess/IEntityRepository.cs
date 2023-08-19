using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
	// new(): must not be abstract or interface.
	public interface IEntityRepository <T> where T :class, IEntity,new()
	{
		void Add(T entity);
		void Update(T entity);
		void Delete(T entity);
		T Get(Expression<Func<T,bool>> expression);
		List<T> GetAll(Expression<Func<T,bool>> expression = null);
	}
}
