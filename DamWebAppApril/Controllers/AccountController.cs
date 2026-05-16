using DamWebAppApril.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Security.Claims;

namespace DamWebAppApril.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppliactionUser> userManager;
        private readonly SignInManager<AppliactionUser> signInManager;

        public AccountController(UserManager<AppliactionUser> userManager,SignInManager<AppliactionUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        #region Register
        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  async Task<IActionResult> Register(RegisterViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //mapping
                AppliactionUser appUser = new AppliactionUser()
                {
                    UserName = userFromReq.UserName,
                    PasswordHash=userFromReq.Password,
                    Address=userFromReq.Address
                };
                //add user db
                IdentityResult result= await userManager.CreateAsync(appUser,userFromReq.Password);
                if (result.Succeeded) {
                    //Assign role to specific user
                    await userManager.AddToRoleAsync(appUser, "Admin");
                    //create cookie
                    await signInManager.SignInAsync(appUser,isPersistent:false);//create cookie (default Claims[id,username,email?,role?])
                    return RedirectToAction("Index", "Employee");
                }
                foreach (var errorItem in result.Errors)
                {
                    ModelState.AddModelError("", errorItem.Description);
                }

            }
            return View("Register",userFromReq);
        }
        #endregion
        #region Login
        public IActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel userFromReq)
        {
            if (ModelState.IsValid)
            {
                //check
                AppliactionUser appUser=await userManager.FindByNameAsync(userFromReq.UserName);
                if (appUser != null)
                {
                    bool found=await userManager.CheckPasswordAsync(appUser,userFromReq.Password);
                    if (found)
                    {
                        //cookie
                        List<Claim> addClaim=new List<Claim>();
                        addClaim.Add(new Claim("Address", appUser.Address));

                        await signInManager.SignInWithClaimsAsync(appUser, userFromReq.RememberMe, addClaim);//id ,name,role?,email?,address
                        return RedirectToAction("Index", "Employee");
                    }
                }
                ModelState.AddModelError("", "invaliad Account");
            }
            return View("Login",userFromReq);
        }
        #endregion

        public async Task<IActionResult> SignOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
