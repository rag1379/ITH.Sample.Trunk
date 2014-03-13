using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace POUM.DataLayer.Interface
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
        T GetById(int id);
        int Delete(T entity);
        int Add(T newEntity);
        int Update(T entityToUpdate);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        List<T> GetAllAsList();
    }
}
