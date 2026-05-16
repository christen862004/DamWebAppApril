using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DamWebAppApril.Controllers
{
    [Authorize(Roles = "Admin")]//search cookie found,search about claim with ype role value admin
    public class RoleController : Controller
    {
        RoleManager<IdentityRole> roleManager;
        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
        //link =>open view
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Submit
        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel roleVM)
        {
            if (ModelState.IsValid)
            {
                //create 
                IdentityRole role = new IdentityRole() { Name=roleVM.RoleName};
                IdentityResult result= await  roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }
            }
            return View("Create",roleVM);
        }
    }
}
