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
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> userMgr, SignInManager<User> signInMgr)
        {
            userManager = userMgr;
            signInManager = signInMgr;
            //IdentitySeedData.EnsurePopulated(userMgr).Wait();
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
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync((User)user, loginModel.Password, false, false)).Succeeded)
                    {
                        //return Redirect(loginModel?.ReturnUrl ?? "Admin/Index");
                        if (loginModel.ReturnUrl != null)
                        {
                            return Redirect(loginModel.ReturnUrl);
                        }
                        else
                        {
                            if (await userManager.IsInRoleAsync((User)user, "Admin"))
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
                User user = new User { Email = registerViewModel.Email, UserName = registerViewModel.Name, Year = registerViewModel.Year };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                await userManager.AddToRoleAsync(user, "User");
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
