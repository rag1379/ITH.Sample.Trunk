using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Entity;
using POUM.DataLayer.Interface;

namespace POUM.DataLayer.Repository
{
    public class ImageDetailRepository : Repository<ImageDetail>, IImageDetailRepository
    {
        private IUnitOfWork unitOfWork = null;

        private IRepository<ImageDetail> repository = null;

        public ImageDetailRepository(IUnitOfWork uow, IRepository<ImageDetail> repositoryBase)
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
