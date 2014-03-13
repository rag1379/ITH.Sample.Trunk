using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Entity;
using POUM.DataLayer;
using POUM.DataLayer.Interface;

namespace POUM.Service.Interface
{
    public interface IMovieService : IRepository<Movie>
    {
        int Save(Movie movieItemToSave);

        
    }
}
