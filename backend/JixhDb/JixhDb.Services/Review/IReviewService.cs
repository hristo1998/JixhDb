namespace JixhDb.Services.Review
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Helpers;
    using JixhDb.Models.BindingModels.Review;

    public interface IReviewService
    {
        string GetMovieReviewsJson(Movie movie);

        List<Review> GetMovieReviews(Movie movie);

        string GetReviewByIdJson(string id);

        Review GetReviewById(string id);

        Task<ServiceResult> Create(User user, Movie movie, ReviewBindingModel model);

        Task<ServiceResult> Update(Review review, ReviewBindingModel model);

        Task<ServiceResult> Delete(Review review);

        Task<ServiceResult> Rate(Review review, User user);

        Task<ServiceResult> UnRate(Review review, User user);
    }
}
