using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using JixhDb.Models.BindingModels.Category;
using JixhDb.Models.BindingModels.Movies;
using JixhDb.Models.BindingModels.Review;
using JixhDb.Models.EntittyModels;
using JixhDb.Models.ViewModels.Category;
using JixhDb.Models.ViewModels.Movies;
using JixhDb.Models.ViewModels.Review;

namespace JixhDb.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(ex =>
            {
                ex.CreateMap<Movie, MovieSearchViewModel>();
            });
        }
    }
}
