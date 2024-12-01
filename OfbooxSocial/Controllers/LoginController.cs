using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfbooxSocial.Models.ViewModels;

namespace OfbooxSocial.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var value = ModelState[key];
                    if (value != null && value.Errors.Count > 0)
                    {
                        ViewData[key + "Error"] = value.Errors.First().ErrorMessage;
                    }

                }
                return View();
            }
            var signInResult = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (signInResult.Succeeded) 
            {
                return RedirectToAction("Index", "Home");
            } 
            else
            {
                if (signInResult.IsNotAllowed)
                {
                    ViewData["LoginError"] = "You are not allowed to log into this account. Please make sure you activated your account.";
                }
                else if(signInResult.IsLockedOut)
                {
                    ViewData["LoginError"] = "You cannot log into your account at this moment. Please try again later.";
                }
                ViewData["LoginError"] = "Incorrect username or password.";
                return View();
            }
        }
    }
}
