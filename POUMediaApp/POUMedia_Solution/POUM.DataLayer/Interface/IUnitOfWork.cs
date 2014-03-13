using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Entity;
using System.Data.Entity;
using System.Data;

namespace POUM.DataLayer.Interface
{
    public interface IUnitOfWork
    {
        int Commit();
        //IRepository<Blog> Blogs { get; }

        DbContext Context { get; }
    }
}
