using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.MVC.Controllers
{
    public class CabinetController : Controller
    {

        private readonly SignInManager<UserEntity> _signInManager;

        public CabinetController(SignInManager<UserEntity> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
