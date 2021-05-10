using Alcoholest.Areas.Administration.Models.InputModels;
using Alcoholest.Areas.Administration.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Alcoholest.Areas.Administration.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Administration")]
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        public IActionResult RoleIndex()
        {
            var roles = this.roleManager
                .Roles
                .ToList();

            return View(roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            var role = this.roleManager.FindByNameAsync(inputModel.Name);

            if (role != null)
            {
                var errorMessage = new ErrorViewModel()
                {
                    ErrorMessage = "Role already exists!",
                };

                return this.View("ErrorView", errorMessage);
            }

            var identityRole = new IdentityRole()
            {
                Name = inputModel.Name,
                NormalizedName = inputModel.NormalizedName,
            };

            await roleManager.CreateAsync(identityRole);
            return RedirectToAction("RoleIndex");
        }
    }
}
