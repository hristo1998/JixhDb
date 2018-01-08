namespace JixhDb.Services.Comments
{
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Helpers;
    using JixhDb.Models.BindingModels.Comments;

    public interface ICommentsService
    {
        string GetMovieCommentsJson(Movie movie);

        List<Comment> GetMovieComments(Movie movie);

        string GetCommentByIdJson(string id);

        Comment GetCommentById(string id);

        Task<ServiceResult> Create(User user, Movie movie, CommentBindingModel model);

        Task<ServiceResult> Update(Comment comment, CommentBindingModel model);

        Task<ServiceResult> Delete(Comment comment);
    }
}
