﻿using System.Web.Http;
using JixhDb.Models.BindingModels.Category;
using JixhDb.Models.BindingModels.Review;
using JixhDb.Models.ViewModels.Category;
using JixhDb.Models.ViewModels.Review;

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
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.Indent = true;

        }


        private void ConfigureMappings()
        {
            Mapper.Initialize(ex =>
            {
                ex.CreateMap<Movie, MovieDetailsViewModel>();
                ex.CreateMap<Movie, MovieShortInfoViewModel>();
                ex.CreateMap<NewMovieBindingModel, Movie>();
                ex.CreateMap<EditMovieBidingModel, Movie>();
                ex.CreateMap<NewCategoryBindingModel, Category>();
                ex.CreateMap<Category, CategoryViewModel>();
                ex.CreateMap<CategoryViewModel, Category>();
                ex.CreateMap<NewReviewBindingModel, Review>();
                ex.CreateMap<Review, ReviewViewModel>();
                ex.CreateMap<Movie, MovieSearchViewModel>()
                .ForMember(vm => vm.MovieUrl, opt => opt.MapFrom( src => "Movies/" + src.Id));
            });
        }
    }
}
