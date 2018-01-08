namespace JixhDb.Services.Movies
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Helpers;
    using JixhDb.Models.BindingModels.Movies;

    public interface IMovieService
    {
        string GetMoviesByCategoryJson(Category category);

        List<Movie> GetMoviesByCategory(Category category);

        string GetMovieByIdJson(string id);

        Movie GetMovieById(string id);

        Task<ServiceResult> Create(MovieBindingModel model);

        Task<ServiceResult> Update(Movie movie, MovieBindingModel model);

        Task<ServiceResult> Delete(Movie model);

        Task<ServiceResult> Rate(Movie movie, User user, double rating);

        Task<ServiceResult> UnRate(Movie movie, User user);
    }
}
