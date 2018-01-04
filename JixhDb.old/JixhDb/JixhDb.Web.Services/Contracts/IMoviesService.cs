using System.Collections.Generic;
using AutoMapper;
using JixhDb.Models.BindingModels.Movies;
using JixhDb.Models.EntittyModels;
using JixhDb.Models.ViewModels.Movies;

namespace JixhDb.Web.Services.Contracts
{
    public interface IMoviesService
    {
        IEnumerable<MovieShortInfoViewModel> Movies();


        IEnumerable<MovieShortInfoViewModel> Movies(string category);


        MovieDetailsViewModel Movie(int id);


        void Add(NewMovieBindingModel movie);

        void Modify(EditMovieBidingModel movie);

        void Delete(int id);
    }
}
