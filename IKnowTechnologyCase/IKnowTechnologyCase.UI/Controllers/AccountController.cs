using IKnowTechnologyCase.BLL.Models.DTOs;
using IKnowTechnologyCase.BLL.Services.AppUserService;
using IKnowTechnologyCase.CORE.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IKnowTechnologyCase.UI.Controllers
{
    [Authorize] // Bu controller'a erişim log in olmuş kullanıcılar tarafından sağlanabilir
    [AutoValidateAntiforgeryToken] //
    public class AccountController : Controller
    {
        private readonly IAppUserService appUserService;
        private SignInManager<AppUser> signInManager;

        public AccountController(IAppUserService appUserService, SignInManager<AppUser> signInManager)
        {
            this.appUserService = appUserService;
            this.signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
          
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserService.Register(model);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, item.Description);
                    TempData["Error"] = "Oops.. Something went wrong  :(";
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult LogIn()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> LogIn(LoginDTO model)
        {
            if (ModelState.IsValid)
            {
                var result = await appUserService.Login(model);
                if (result.Succeeded)
                {
                    return RedirectToAction("NotebookList", "AppUser" );
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }


}

