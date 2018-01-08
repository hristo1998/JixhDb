namespace JixhDb.Services.Movies.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using JixhDb.Data;
    using JixhDb.Models.EntityModels;
    using JixhDb.Models.BindingModels.Movies;
    using JixhDb.Services.Helpers;
    using Newtonsoft.Json;
    using AutoMapper;

    public class MovieService : IMovieService, IService
    {
        private readonly JixhDbContext db;

        public MovieService(JixhDbContext db)
        {
            this.db = db;
        }

        public string GetMoviesByCategoryJson(Category category)
            => JsonConvert.SerializeObject(this.GetMoviesByCategory(category));

        public List<Movie> GetMoviesByCategory(Category category)
            => this.db.Movies
            .Where(movie => movie.Categories.Any(mc => mc.CategoryId == category.Id))
            .ToList();

        public string GetMovieByIdJson(string id)
            => JsonConvert.SerializeObject(this.GetMovieById(id));

        public Movie GetMovieById(string id)
            => this.db.Movies.FirstOrDefault(m => m.Id == id);

        public async Task<ServiceResult> Create(MovieBindingModel model)
        {
            var result = new ServiceResult();

            var movie = new Movie();
            Mapper.Map(model, movie);

            try
            {
                await this.db.Movies.AddAsync(movie);
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult> Update(Movie movie, MovieBindingModel model)
        {
            var result = new ServiceResult();
            try
            {
                Mapper.Map(model, movie);

                model.CategoriesString.Split(", ")
                    .ToList()
                    .Select(catStr => this.db.Categories.FirstOrDefault(c => c.Name == catStr))
                    .ToList()
                    .ForEach(cat => movie.Categories.Add(new MovieCategory { Category = cat, CategoryId = cat.Id, Movie = movie, MovieId = movie.Id }));

                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException sx)
            {
                result.Error = sx.Message;
                result.Succeeded = false;
            }

            return result;
        }

        public async Task<ServiceResult> Delete(Movie movie)
        {
            var result = new ServiceResult();

            try
            {
                this.db.Movies.Remove(movie);
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult> Rate(Movie movie, User user, double rating)
        {
            var result = new ServiceResult();

            var movieRaiting = new MovieRaiting
            {
                User = user,
                UserId = user.Id,
                Movieid = movie.Id,
                Rate = rating
            };
            movieRaiting.Movie = movie;

            try
            {
                movie.Ratings.Add(movieRaiting);
                movie.Rating = movie.Ratings.Sum(r => r.Rate) / movie.Ratings.Count;
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult> UnRate(Movie movie, User user)
        {
            var result = new ServiceResult();

            var movieRaiting = await this.db.MovieRatings.FirstOrDefaultAsync(mr => mr.Movieid == movie.Id && mr.UserId == user.Id);

            try
            {
                movie.Ratings.Remove(movieRaiting);
                movie.Rating = movie.Ratings.Sum(r => r.Rate) / movie.Ratings.Count;
                await this.db.SaveChangesAsync();
                result.Succeeded = true;
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }
    }
}