using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using POUM.Service.Interface;
using POUM.DataLayer.Interface;
using POUM.DataLayer.Repository;
using POUM.Entity;


namespace POUM.Service
{
    public class MovieService : Repository<Movie>, IMovieService
    {
         private IUnitOfWork uow = null;

        private IMovieRepository repository = null;



        public MovieService(IMovieRepository movieRepository, IUnitOfWork unitOFWork) 
            : base(unitOFWork)
        {

            this.uow = unitOFWork;
            this.repository = movieRepository;
        }

        /// <summary>
        /// Saves the specified movie item to save.
        /// </summary>
        /// <param name="movieItemToSave">The movie item to save.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public int Save(Movie movieItemToSave)
        {
            try
            {
                if (movieItemToSave.MovieId <= 0)
                {
                    return this.repository.Add(movieItemToSave);
                }
                else
                {
                    return this.repository.Update(movieItemToSave);
                }
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        //public int Delete(MovieDB.Model.Movie movieIdToDelete)
        //{
        //    if (movieIdToDelete != null)
        //    {
        //        return this.repository.Remove(movieIdToDelete);
        //    }
        //    return 0;
        //}
    }
}
