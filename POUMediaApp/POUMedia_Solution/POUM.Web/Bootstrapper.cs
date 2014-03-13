using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc4;

using POUM.Web;
using POUM.Entity;
using POUM.Service;
using POUM.Service.Interface;
using POUM.Web.Controllers;


namespace POUM.Web
{
  public static class Bootstrapper
  {
    public static IUnityContainer Initialise()
    {
      var container = BuildUnityContainer();

      DependencyResolver.SetResolver(new UnityDependencyResolver(container));

      return container;
    }

    private static IUnityContainer BuildUnityContainer()
    {
      var container = new UnityContainer();

      // register all your components with the container here
      // it is NOT necessary to register your controllers

      // e.g. container.RegisterType<ITestService, TestService>();    
      RegisterTypes(container);

      return container;
    }

    public static void RegisterTypes(IUnityContainer container)
    {
        //Presenter / Web Layer
        container.RegisterType<IController, AccountController>();
        container.RegisterType<IController, HomeController>();
        //container.RegisterType<IController, MovieTypeController>();
        //container.RegisterType<IController, ImageUploadController>();


        //Service Layer        
        container.RegisterType<IMovieService, MovieService>();        
        container.RegisterType<IImageDetailService, ImageDetailService>();

        ////Data Layer            
        //container.RegisterType<IImageDetailRepository, ImageDetailRepository>();
        //container.RegisterType<IBlogRepository, BlogRepository>();
        //container.RegisterType<IMovieRepository, MovieRepository>();
        //container.RegisterType<IMovieTypeRepository, MovieTypeRepository>();
        //container.RegisterType<IUnitOfWork, MovieDB.Data.Repository.UnitOfWork>();
        //container.RegisterType(typeof(IRepository<>), typeof(Repository<>));
    }
  }
}