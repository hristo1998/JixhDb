namespace JixhDb.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Jwt;
    using JixhDb.Data;
    using JixhDb.Models.BindingModels.User;
    using JixhDb.Services.Account;
    using Newtonsoft.Json;
    
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IJwtSecurityTokenService _jwt;
        private readonly JixhDbContext _data;


        public AccountController(
            IUserService userService,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            JixhDbContext data,
            IJwtSecurityTokenService jwt
            )
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _jwt = jwt;
            _data = data;
        }

        [HttpGet]
        [Authorize(Roles ="Admin")]
        public IActionResult GetAll()
        {
            var res = _data.Users.ToList();  // Redo / Refactor
            return Ok(JsonConvert.SerializeObject(res));
        }

        [HttpGet("{id}", Name ="GetUser")]
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
        public async Task<IActionResult> Create(RegisterUserBindingModel model)
        {
            if (ModelState.IsValid)
            {                
                var user = new User { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return CreatedAtRoute("GetUser", new { Email = model.Email });
                }                
            }

            // If we got this far, something failed miserablyyyyaaahhthththth
            return BadRequest();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> Update(EditUserBindingModel model)
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

                var result = await _userService.UpdateUserAsync(user.Id, model);
                
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

            var result  = await _userManager.DeleteAsync(user);

            if (result.Succeeded)
            {
                return NoContent();
            }

            return BadRequest();
        }
    }
}
