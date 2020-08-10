using LBD.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LBD.Domain.EF.IRepository
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task<List<T>> GetAllAsync();
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression);
		Task<T> CreateAsync(T entity);
		T Update(T entity);
		T Delete(T entity);
	}
}
