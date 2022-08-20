using AutoMapper;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.MVC.ViewModels;
using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.MVC.Controllers
{
    [Authorize]
    public class CabinetController : Controller
    {

        private readonly SignInManager<UserEntity> _signInManager;

        private readonly IUsersService _usersService;

        private readonly IMapper _mapper;
        public CabinetController(SignInManager<UserEntity> signInManager, IUsersService usersService, IMapper mapper)
        {
            _signInManager = signInManager;

            _usersService = usersService;

            _mapper = mapper;
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
