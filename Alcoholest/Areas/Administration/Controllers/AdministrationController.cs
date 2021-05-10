using Alcoholest.Areas.Administration.Models.InputModels;
using Alcoholest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Alcoholest.Areas
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class AdministrationController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AdministrationController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }


        public IActionResult CreateAdminUser()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdminUser(CreateAdminInputModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var user = new ApplicationUser {UserName = inputModel.Email, Email = inputModel.Email };
                var result = await this._userManager.CreateAsync(user, inputModel.Password);

                if (result.Succeeded)
                {
                    var currentUser = await _userManager.FindByNameAsync(user.UserName);
                    await _userManager.AddToRoleAsync(currentUser, "Admin");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect("/Home/Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return this.View();
        }
    }
}
