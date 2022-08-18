using FunpayGold.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;

            _mediator = mediator;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                return Redirect("/Home/Index");
            }
            return null;
        }

        [HttpPost]
        public async Task SignIn(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {

            }
        }
    }
}