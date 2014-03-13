using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;
using POUM.Entity;

namespace POUM.DataLayer
{
    public class MovieDbContext:DbContext
    {
        public MovieDbContext()
            : base("POUM_Connection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            
        }
        

        public DbSet<Movie> Movies { get; set; }

       
        public DbSet<ImageDetail> ImageDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>().MapToStoredProcedures()

        }
    }
}
