using JixhDb.Models.BindingModels.Movies;

namespace JixhDb.Web.Services
{
    using System.Linq;
    using JixhDb.Models.ViewModels.Movies;
    using System.Collections.Generic;
    using JixhDb.Models.EntittyModels;
    using AutoMapper;


    using JixhDb.Web.Services.Contracts;
    using System;

    public class MoviesService : Service, IMoviesService
    {
        public IEnumerable<MovieShortInfoViewModel> Movies()
        {
            var movies = this.Context.Movies.Entities.OrderByDescending(movie => movie.ReleaseDate);
            return Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieShortInfoViewModel>>(movies);
        }

        public IEnumerable<MovieShortInfoViewModel> Movies(string category)
        {
            var movies =
                this.Context.Movies.Where(movie => movie.Categories.Any(cat => cat.Name.Equals(category)))
                    .OrderByDescending(movie => movie.ReleaseDate);
            return Mapper.Map<IEnumerable<Movie>, IEnumerable<MovieShortInfoViewModel>>(movies);
        }

        public MovieDetailsViewModel Movie(int id)
        {
            return Mapper.Map<Movie, MovieDetailsViewModel>(this.Context.Movies.Find(id));
        }

        public void Add(NewMovieBindingModel movie)
        {
            var newMovie = Mapper.Map<NewMovieBindingModel, Movie>(movie);
            this.Context.Movies.Add(newMovie);
            this.Context.SaveChanges();
        }

        public void Modify(EditMovieBidingModel movie)
        {
            var oldEdit = this.Context.Movies.Find(movie.Id);

            oldEdit.Title = movie.Title;
            oldEdit.CoverUrl = movie.CoverUrl;
            oldEdit.TrailerLink = movie.TrailerLink;
            oldEdit.Duration = movie.Duration;
            oldEdit.ReleaseDate = movie.ReleaseDate;
            oldEdit.Director = movie.Director;
            oldEdit.Writers = movie.Writers;
            oldEdit.Cast = movie.Cast;
            oldEdit.Storyline = movie.Storyline;
            oldEdit.Rating = movie.Rating;

            this.Context.SaveChanges();
        }

        public void Delete(int id)
        {
            this.Context.Movies.Remove(id);
            this.Context.SaveChanges();
        }

       


    }
}