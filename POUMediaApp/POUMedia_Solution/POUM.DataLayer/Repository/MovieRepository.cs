using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.DataLayer.Interface;
using POUM.Entity;

namespace POUM.DataLayer.Repository 
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {

        private IUnitOfWork unitOfWork = null;

        private IRepository<Movie> repository = null;

        public MovieRepository(IUnitOfWork uow, IRepository<Movie> repositoryBase)
            : base(uow)
        {
            if (uow == null)
            {
                throw new ArgumentNullException("Unit Of Work");
            }
            else
            {
                unitOfWork = uow;
                this.repository = repositoryBase;
            }
        }
    }
}
