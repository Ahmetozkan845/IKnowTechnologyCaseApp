using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.CORE.IRepositories
{
    public interface IBaseRepository<T>where T : class
    {
        Task Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
        Task<List<T>> GetAllWhere(Expression<Func<T, bool>> expression);
        Task<bool> Any(Expression<Func<T, bool>> expression);   
        Task<T> GetWhere(Expression<Func<T, bool>> expression);
        //Tek entity için
        Task<TResult> GetFilteredFirstOrDefault<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);

        //Multiple için
        Task<List<TResult>> GetFilteredList<TResult>(
            Expression<Func<T, TResult>> selector,
            Expression<Func<T, bool>> expression,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> includes = null);


    }
}
