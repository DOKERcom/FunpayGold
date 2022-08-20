using AutoMapper;
using FunpayGold.Application.Commands.HomeController;
using FunpayGold.Application.Models;
using FunpayGold.Common.Models;
using FunpayGold.MVC.Initializators.Intefaces;
using FunpayGold.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        private readonly IAdminInitializer _adminInitializer;

        private readonly IRoleInitializer _roleInitializer;

        public HomeController(ILogger<HomeController> logger, 
            IMediator mediator, IMapper mapper, 
            IRoleInitializer roleInitializer, IAdminInitializer adminInitializer)
        {
            _logger = logger;

            _mediator = mediator;

            _mapper = mapper;

            _roleInitializer = roleInitializer;

            _adminInitializer = adminInitializer;

            Initializer().Wait();
        }

        public async Task Initializer()
        {
            await _roleInitializer.Initialize();

            await _adminInitializer.Initialize();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<RegisterModel>(viewModel);

                var result = await _mediator.Send(new RegisterCommand(model));

                return Json(result);
            }
            return Json(new ResultActionModel(400, "Одно или несколько полей заполнены не верно!"));
        }

        [HttpPost]
        public async Task<JsonResult> SignIn(SignInViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var model = _mapper.Map<SignInModel>(viewModel);

                var result = await _mediator.Send(new SignInCommand(model));

                return Json(result);
            }
            return Json(new ResultActionModel(400, "Одно или несколько полей заполнены не верно!"));
        }
    }
}