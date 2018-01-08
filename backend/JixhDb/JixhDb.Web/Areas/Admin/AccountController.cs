namespace JixhDb.Web.Areas.Admin
{
    using System.Threading.Tasks;
    
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using JixhDb.Models.BindingModels.User;
    using JixhDb.Models.EntityModels;
    using JixhDb.Services.Account;
    using static JixhDb.Common.GlobalConstants;

    [Route("api/admin/[controller]")]
    [Authorize(Roles = AdministratorRoleName)]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] EditUserBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                {
                    return NotFound();
                }

                // Check moderators password
                var moderator = await _userManager.FindByNameAsync(User.Identity.Name);
                var passwordCorrect = await _userManager.CheckPasswordAsync(moderator, model.Password);

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
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
