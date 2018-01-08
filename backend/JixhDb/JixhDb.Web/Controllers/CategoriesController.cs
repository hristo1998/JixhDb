namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;
    using JixhDb.Services.Categories;
    using static JixhDb.Common.GlobalConstants;
    using JixhDb.Models.BindingModels.Category;

    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        // Get all categories
        // GET api/categories/
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(this._categoryService.GetAllCategoriesJson());
        }

        // Get a category
        // GET api/categories/id
        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetById(string id)
        {
            var category = this._categoryService.GetCategoryByIdJson(id);

            if (category == "null")
            {
                return NotFound();
            }

            return Json(category);
        }

        // Create a category
        // POST api/categories
        [HttpPost]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Create([FromBody] CategoryBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await this._categoryService.Create(model);

                if (result.Succeeded)
                {
                    return CreatedAtRoute("GetCategory", model);
                }
            }

            return BadRequest();
        }

        // Edit category
        // PUT api/categories/{id}
        [HttpPut("{id}")]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Update(string id, [FromBody] CategoryBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var category = this._categoryService.GetCategoryById(id);

                if (category == null)
                {
                    return NotFound();
                }

                var result = await this._categoryService.Update(category, model);

                if (result.Succeeded)
                {
                    return Ok();
                }
            }

            return BadRequest();
        }

        // Delete category
        // DELETE api/categories
        [HttpDelete("{id}")]
        [Authorize(Roles = MovieModeratorRoleName)]
        public async Task<IActionResult> Delete(string id)
        {
            var category = this._categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }

            var result = await this._categoryService.Delete(category);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }

    }
}
