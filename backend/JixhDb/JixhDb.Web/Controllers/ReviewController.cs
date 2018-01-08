namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using JixhDb.Services.Review;
    using JixhDb.Services.Movies;
    using JixhDb.Models.BindingModels.Review;
    using JixhDb.Models.EntityModels;

    [Route("api/reviews")]
    public class ReviewController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IReviewService _reviewService;
        private readonly IMovieService _movieService;

        public ReviewController(IReviewService reviewService,
            IMovieService movieService,
            UserManager<User> userManager)
        {
            this._reviewService = reviewService;
            this._movieService = movieService;
            this._userManager = userManager;
        }


        // Get reviews for e movie
        // GET api/reviews?movieId={id}
        [HttpGet]
        public IActionResult GetAll([FromQuery] string movieId)
        {
            var movie = this._movieService.GetMovieById(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            var reviews = this._reviewService.GetMovieReviewsJson(movie);
            return Json(reviews);
        }

        // Get specific movie review
        // GET /api/comments/{id}
        [HttpGet("{id}", Name = "GetReview")]
        public IActionResult GetById(string id)
        {
            var review = this._reviewService.GetReviewByIdJson(id);

            if (review == "null")
            {
                return NotFound();
            }

            return Json(review);
        }

        // Add a new review
        // POST /api/reviews
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] ReviewBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = this._movieService.GetMovieById(model.movieId);

                if (movie == null)
                {
                    return NotFound();
                }

                var user = await this._userManager.FindByNameAsync(User.Identity.Name);

                var result = await this._reviewService.Create(user, movie, model);

                if (result.Succeeded)
                {
                    return CreatedAtRoute("GetUser", model);
                }
            }

            return BadRequest();
        }

        // Edits a reviews
        // PUT /api/reviews/{id}
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(string id, [FromBody] ReviewBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = this._movieService.GetMovieById(model.movieId);
                var review = this._reviewService.GetReviewById(id);

                if (movie == null || review == null)
                {
                    return NotFound();
                }

                var user = await this._userManager.FindByNameAsync(User.Identity.Name);

                if (review.UserId != user.Id)
                {
                    return BadRequest();
                }

                var result = await this._reviewService.Update(review, model);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        // Delete a review
        // DELETE /api/reviews/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(string id)
        {
            var review = this._reviewService.GetReviewById(id);

            if (review == null)
            {
                return NotFound();
            }

            var user = await this._userManager.FindByNameAsync(User.Identity.Name);

            if (review.UserId != user.Id)
            {
                return BadRequest();
            }

            var result = await this._reviewService.Delete(review);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
