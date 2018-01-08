namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Identity;
    using JixhDb.Services.Comments;
    using JixhDb.Services.Movies;
    using JixhDb.Services.Review;
    using JixhDb.Models.EntityModels;

    [Authorize]
    [Route("api/[controller]")]
    public class RatingsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IMovieService _movieService;
        private readonly IReviewService _reviewService;
        private readonly ICommentsService _commentsService;

        public RatingsController(
            UserManager<User> _userManager,
            IMovieService movieService,
            IReviewService reviewService,
            ICommentsService commentsService
            )
        {
            this._movieService = movieService;
            this._reviewService = reviewService;
            this._commentsService = commentsService;
            this._userManager = _userManager;
        }

        // POST api/ratings/movie/id
        [Route("rate/{id}")]
        [HttpPost]
        public async Task<IActionResult> RateMovie(string id, double rating)
        {
            var movie = this._movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._movieService.Rate(movie, user, rating);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELTE api/ratings/movie/id
        [Route("unrate/{id}")]
        [HttpPost]
        public async Task<IActionResult> UnRateMovie(string id)
        {
            var movie = this._movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._movieService.UnRate(movie, user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        // POST api/ratings/review/id
        [Route("rate/{id}")]
        [HttpGet]
        public async Task<IActionResult> RateReview(string id)
        {
            var review = this._reviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._reviewService.Rate(review, user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELTE api/ratings/review/id
        [Route("unrate/{id}")]
        [HttpPost]
        public async Task<IActionResult> UnRateReview(string id)
        {
            var review = this._movieService.GetMovieById(id);

            if (review == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._movieService.UnRate(review, user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        // POST api/ratings/comment/id
        [Route("rate/{id}")]
        [HttpGet]
        public async Task<IActionResult> RateComment(string id)
        {
            var comment = this._commentsService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._commentsService.Rate(comment, user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

        // DELTE api/ratings/comment/id
        [Route("unrate/{id}")]
        [HttpPost]
        public async Task<IActionResult> UnRateComment(string id)
        {
            var comment = this._commentsService.GetCommentById(id);

            if (comment == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);
            var result = await this._commentsService.UnRate(comment, user);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
