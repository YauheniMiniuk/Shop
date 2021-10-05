using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Shop.Models.ViewModels;
using Shop.Models;

namespace Shop.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signInMgr, RoleManager<IdentityRole> roleMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;
            // Для создания роли Админа
            //IdentitySeedData.SeedRoles(roleManager).Wait();
            //IdentitySeedData.EnsurePopulated(userMgr, roleManager).Wait();
        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        //return Redirect(loginModel?.ReturnUrl ?? "Admin/Index");
                        if (loginModel.ReturnUrl != null)
                        {
                            return Redirect(loginModel.ReturnUrl);
                        }
                        else
                        {
                            if (await userManager.IsInRoleAsync(user, "Admin"))
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            return Redirect("/");
                        }
                    }
                }
            }
            ModelState.AddModelError("", "Неправильное имя или пароль");
            return View(loginModel);
        }
        [AllowAnonymous]
        public ViewResult Registration() => View();

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser(registerViewModel.Name);
                user.Email = registerViewModel.Email;
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(registerViewModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
