namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using JixhDb.Services.Comments;
    using JixhDb.Services.Movies;
    using JixhDb.Models.BindingModels.Comments;
    using JixhDb.Models.EntityModels;

    [Route("api/comments")]
    public class CommentsController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly ICommentsService _commentsService;
        private readonly IMovieService _movieService;

        public CommentsController(ICommentsService commentsService,
            IMovieService movieService,
            UserManager<User> userManager)
        {
            this._commentsService = commentsService;
            this._movieService = movieService;
            this._userManager = userManager;
        }

        // Get comments for e movie
        // GET api/comments?movieId={id}
        [HttpGet]
        public IActionResult GetAll([FromQuery] string movieId)
        {
            var movie = this._movieService.GetMovieById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var comments = this._commentsService.GetMovieCommentsJson(movie);
            return Json(comments);
        }

        // Get specific movie comment
        // GET /api/comments/{id}
        [HttpGet("{id}", Name = "GetComment")]
        public IActionResult GetById(string id)
        {
            var comment = this._commentsService.GetCommentByIdJson(id);

            if (comment == "null")
            {
                return NotFound();
            }

            return Json(comment);
        }

        // Add a new comment
        // POST /api/comments
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CommentBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = this._movieService.GetMovieById(model.movieId);

                if (movie == null)
                {
                    return NotFound();
                }

                var user = await this._userManager.FindByNameAsync(User.Identity.Name);

                var result = await this._commentsService.Create(user, movie, model);

                if (result.Succeeded)
                {
                    return CreatedAtRoute("GetUser", model);
                }
            }

            return BadRequest();
        }

        // Edits a comment
        // PUT /api/comments/{id}
        [HttpPut("{id}")]
        [Authorize]
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

                var user = await this._userManager.FindByNameAsync(User.Identity.Name);

                if (comment.UserId != user.Id)
                {
                    return BadRequest();
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
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var comment = this._commentsService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);

            if (comment.UserId != user.Id)
            {
                return BadRequest();
            }

            var result = await this._commentsService.Delete(comment);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
