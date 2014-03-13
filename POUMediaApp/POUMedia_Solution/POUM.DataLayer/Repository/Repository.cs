using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POUM.DataLayer.Interface;
using System.Data.Entity;

namespace POUM.DataLayer.Repository
{
    public class Repository<T> : IRepository<T>, IDisposable
        where T : class
    {
        protected DbContext DbContext { get; set; }
        protected DbSet<T> DbSet { get; set; }

        protected IUnitOfWork unitOfWork { get; set; }

        
        public Repository(IUnitOfWork uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("Unit Of Work");
            }
            else
            {
                unitOfWork = uow;
                DbContext = uow.Context;
                DbSet = DbContext.Set<T>();
            }
        }

        public IQueryable<T> GetAll()
        {
            return DbSet;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public List<T> GetAllAsList()
        {
            return DbSet.ToList();
        }

        public IQueryable<T> Find(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual int Delete(T entity)
        {
            try
            {
                DbSet.Remove(entity);
                return this.unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual int Add(T newEntity)
        {
            T newEntityAfterAdding = DbSet.Add(newEntity);            
            return this.unitOfWork.Commit();
        }

        
        public virtual int Update(T entityToUpdate)
        {
            try
            {
                DbSet.Attach(entityToUpdate);
                DbContext.Entry(entityToUpdate).State = EntityState.Modified;
                return this.unitOfWork.Commit();                
                //this.DbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
           
        } 
        
        #region IDisposable Members


        public void Dispose()
        {
            if (DbContext != null)
                DbContext.Dispose();

            GC.SuppressFinalize(this);
        }
        #endregion
    }
    
}
