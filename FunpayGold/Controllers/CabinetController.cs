using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.MVC.Controllers
{
    public class CabinetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
