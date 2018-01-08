namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static JixhDb.Common.GlobalConstants;
    using JixhDb.Services.Movies;
    using JixhDb.Services.Categories;
    using JixhDb.Models.BindingModels.Movies;

    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;


        public MoviesController(IMovieService movieService,
            ICategoryService categoryService)
        {
            this._movieService = movieService;
            this._categoryService = categoryService;
        }

        // Get moveis by category
        // GET api/movies?categoryName={name}
        [HttpGet]
        public IActionResult GetAll([FromQuery] string categoryName)
        {
            var category = _categoryService.GetCategoryByName(categoryName);

            if (category == null)
            {
                return NotFound();
            }

            var movies = this._movieService.GetMoviesByCategoryJson(category);

            return Json(movies);
        }

        // Get a movie by id
        // GET api/movies/{id}
        [HttpGet("{id}", Name = "GetMovie")]
        public IActionResult GetById(string id)
        {
            var movie = this._movieService.GetMovieByIdJson(id);

            if (movie == "null")
            {
                return NotFound();
            }

            return Json(movie);
        }

        // Add a movie
        // POST api/movies
        [HttpPost]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Create([FromBody]MovieBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this._movieService.Create(model);

                if (result.Succeeded)
                {
                    return CreatedAtRoute("GetMovie", model);
                }
            }

            return BadRequest();
        }

        // Update a movie
        // PUT /api/moveis/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Update(string id, [FromBody] MovieBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var movie = this._movieService.GetMovieById(id);

                if (movie == null)
                {
                    return NotFound();
                }

                var result = await this._movieService.Update(movie, model);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        // Delete a movie
        // DELTE api/movies/{id}
        [HttpDelete("{id}")]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            var movie = this._movieService.GetMovieById(id);

            if (movie == null)
            {
                return NotFound();
            }

            var result = await this._movieService.Delete(movie);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}