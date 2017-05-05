namespace JixhDb.Web
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using JixhDb.Models.ViewModels.Movies;
    using JixhDb.Models.EntittyModels;
    using JixhDb.Models.BindingModels.Movies;



    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }


        private void ConfigureMappings()
        {
            Mapper.Initialize(ex =>
            {
                ex.CreateMap<Movie, MovieDetailsViewModel>();
                ex.CreateMap<Movie, MovieShortInfoViewModel>();
                ex.CreateMap<NewMovieBindingModel, Movie>();
                ex.CreateMap<EditMovieBidingModel, Movie>();

            });
        }
    }
}
