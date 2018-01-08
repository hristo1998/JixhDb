namespace JixhDb.Web.Areas.Moderator
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using JixhDb.Services.Comments;
    using JixhDb.Services.Movies;
    using JixhDb.Models.BindingModels.Comments;
    using static JixhDb.Common.GlobalConstants;

    [Route("api/moderator/[controller]")]
    [Authorize(Roles = ModeratorRoleName)]
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        private readonly IMovieService _movieService;

        public CommentsController(ICommentsService commentsService,
            IMovieService movieService)
        {
            this._commentsService = commentsService;
            this._movieService = movieService;
        }

        // Edits a comment
        // PUT /api/comments/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] CommentBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = this._movieService.GetMovieById(model.movieId);
                var comment = this._commentsService.GetCommentById(id);

                if (movie == null || comment == null)
                {
                    return NotFound();
                }                

                var result = await this._commentsService.Update(comment, model);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        // Delete a comment
        // DELETE /api/comments/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var comment = this._commentsService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }
            
            var result = await this._commentsService.Delete(comment);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}
