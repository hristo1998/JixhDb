namespace JixhDb.Services.Comments.Implementations
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using JixhDb.Models.BindingModels.Comments;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Helpers;
    using JixhDb.Data;
    using Newtonsoft.Json;
    using AutoMapper;

    public class CommentsService : ICommentsService, IService
    {
        private readonly JixhDbContext db;

        public CommentsService(JixhDbContext db)
        {
            this.db = db;
        }        

        public string GetMovieCommentsJson(Movie movie) 
            => JsonConvert.SerializeObject(this.GetMovieComments(movie));

        public List<Comment> GetMovieComments(Movie movie) 
            => movie.Comments.ToList();

        public string GetCommentByIdJson(string id) 
            => JsonConvert.SerializeObject(this.GetCommentById(id));

        public Comment GetCommentById(string id) 
            => this.db.Comments.FirstOrDefault(c => c.Id == id);

        public async Task<ServiceResult> Create(User user, Movie movie, CommentBindingModel model)
        {
            var result = new ServiceResult();

            var comment = new Comment
            {
                Movie = movie,
                MovieId = movie.Id,
                User = user,
                UserId = user.Id,
                DateCreated = DateTime.Now
            };

            Mapper.Map(model, comment);

            try
            {
                await this.db.Comments.AddAsync(comment);
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

        public async Task<ServiceResult> Update(Comment comment, CommentBindingModel model)
        {
            var result = new ServiceResult();

            Mapper.Map(model, comment);

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

        public async Task<ServiceResult> Delete(Comment comment)
        {
            var result = new ServiceResult();           

            try
            {
                this.db.Comments.Remove(comment);
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
