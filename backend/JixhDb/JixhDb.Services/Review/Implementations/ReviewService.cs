namespace JixhDb.Services.Review.Implementations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using JixhDb.Models.BindingModels.Review;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Helpers;
    using JixhDb.Data;
    using Newtonsoft.Json;
    using AutoMapper;

    public class ReviewService : IReviewService, IService
    {

        private readonly JixhDbContext db;

        public ReviewService(JixhDbContext db)
        {
            this.db = db;
        }


        public string GetMovieReviewsJson(Movie movie) 
            => JsonConvert.SerializeObject(this.GetMovieReviews(movie));


        public List<Review> GetMovieReviews(Movie movie) 
            => movie.Reviews.ToList();

        public string GetReviewByIdJson(string id)
            => JsonConvert.SerializeObject(this.GetReviewById(id));

        public Review GetReviewById(string id)
            => this.db.Reviews.FirstOrDefault(c => c.Id == id);

        public async Task<ServiceResult> Create(User user, Movie movie, ReviewBindingModel model)
        {
            var result = new ServiceResult();

            var review = new Review
            {
                Movie = movie,
                MovieId = movie.Id,
                User = user,
                UserId = user.Id,
                DateCreated = DateTime.Now
            };

            Mapper.Map(model, review);

            try
            {
                await this.db.Reviews.AddAsync(review);
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

        public async Task<ServiceResult> Update(Review review, ReviewBindingModel model)
        {
            var result = new ServiceResult();

            Mapper.Map(model, review);

            try
            {
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

        public async Task<ServiceResult> Delete(Review review)
        {
            var result = new ServiceResult();

            try
            {
                this.db.Reviews.Remove(review);
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

        public async Task<ServiceResult> Rate(Review review, User user)
        {
            var result = new ServiceResult();

            try
            {
                if (user.ReviewsRated.Any(rr => rr.Id != review.Id))
                {
                    review.Rating++;
                    user.ReviewsRated.Add(review);
                    await this.db.SaveChangesAsync();
                    result.Succeeded = true;
                }                
            }
            catch (DbUpdateException ex)
            {
                result.Succeeded = false;
                result.Error = ex.Message;
            }

            return result;
        }

        public async Task<ServiceResult> UnRate(Review review, User user)
        {
            var result = new ServiceResult();

            try
            {
                if (user.ReviewsRated.Any(rr => rr.Id == review.Id))
                {
                    review.Rating--;
                    user.ReviewsRated.Remove(review);
                    await this.db.SaveChangesAsync();
                    result.Succeeded = true;
                }
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
