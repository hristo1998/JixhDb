namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using JixhDb.Models.EntityModels;
    using JixhDb.Models.BindingModels.User;
    using JixhDb.Services.Account;
    using static JixhDb.Common.GlobalConstants;
    using Newtonsoft.Json;

    [Route("api/account")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public AccountController(
            IUserService userService,
            UserManager<User> userManager
            )
        {
            _userService = userService;
            _userManager = userManager;
        }

        // GET api/account
        [HttpGet]
        [Authorize(Roles = AdministratorRoleName)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllUsers();  // Redo / Refactor
            return Ok(JsonConvert.SerializeObject(users));
        }

        // GET api/account/{id}
        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetById(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }

        // Register a new user into the app
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RegisterUserBindingModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    var user = new User { UserName = model.Username, Email = model.Email };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if (result.Succeeded)
                    {
                        return CreatedAtRoute("GetUser", new { Email = model.Email });
                    }
                }
            }

            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody]EditUserBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var userName = User.Identity.Name;
                var user = await _userManager.FindByNameAsync(userName);

                if (user == null)
                {
                    return NotFound();
                }

                var passwordCorrect = await _userManager.CheckPasswordAsync(user, model.Password);

                if (!passwordCorrect)
                {
                    return BadRequest();
                }

                var result = await _userService.UpdateUserAsync(user, model);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest(result.Error);
                }
            }

            return BadRequest();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> Delete()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
