using System;
using JixhDb.Data;
using JixhDb.Models.BindingModels.Review;

namespace JixhDb.Web.Services
{
    using AutoMapper;
    using JixhDb.Models.EntittyModels;
    using JixhDb.Models.ViewModels.Review;
    using JixhDb.Web.Services.Contracts;

    public class ReviewService : Service, IReviewService
    {
        public ReviewViewModel Find(int id)
        {
            return Mapper.Map<Review, ReviewViewModel>(this.Context.Reviews.Find(id));
        }

        public int Add(NewReviewBindingModel review, string userId)
        {
          
            var newReview = Mapper.Map<NewReviewBindingModel, Review>(review);
            newReview.DateTime = DateTime.Now;;
            newReview.Movie = this.Context.Movies.Find(review.MovieId);
            newReview.Reviewer = this.Context.Users.Find(userId);

            this.Context.Reviews.Add(newReview);
            this.Context.SaveChanges();
            return newReview.Id;

        }
    }
}
