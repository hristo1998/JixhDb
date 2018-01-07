namespace JixhDb.Web.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using JixhDb.Services.Jwt;
    using JixhDb.Models.EntityModels;
    using JixhDb.Models.BindingModels.Jwt;
    using JixhDb.Data;

    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IJwtSecurityTokenService _jwt;
        
        public TokenController(
            SignInManager<User> signInManager,
            UserManager<User> userManager,
            IJwtSecurityTokenService jwt) 
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwt = jwt;
        }


        // Logins the user 
        [Route("token")]
        public async Task<IActionResult> GetToken(LoginBidingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    var user = await _signInManager.UserManager.FindByEmailAsync(model.Email);
                    var roles = await _signInManager.UserManager.GetRolesAsync(user);
                    return new ObjectResult(_jwt.CreateToken(model.Email, roles));
                }
                else
                {
                    return Unauthorized();
                }
            }

            return Unauthorized();
        }
    }
}
