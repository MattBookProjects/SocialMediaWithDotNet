using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OfbooxSocial.Models.ViewModels;
namespace OfbooxSocial.Controllers
{
    public class RegisterController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;

        public RegisterController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid) {
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
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                ViewData["UsernameError"] = "This username is already taken";
                return View();
            }
            var createResult = await _userManager.CreateAsync(new IdentityUser() {UserName = model.Username, Email = model.Email }, model.Password);
            if (createResult.Succeeded) {
                return View("Success");
            }
            else
            {
                ViewData["ServerError"] = "The server encountered an error while processing your request. Please try again later";
                foreach (var err in createResult.Errors)
                {
                    Console.WriteLine(err.Description);
                }
                return View();
            }

            
        }
    }
}
