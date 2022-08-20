using AutoMapper;
using FunpayGold.Application.Commands.AdminPanelController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.Models;
using FunpayGold.MVC.ViewModels;
using FunpayGold.Persistence.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FunpayGold.MVC.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminPanelController : Controller
    {


        private readonly SignInManager<UserEntity> _signInManager;

        private readonly IUsersService _usersService;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;
        public AdminPanelController(
            SignInManager<UserEntity> signInManager, 
            IUsersService usersService, 
            IMapper mapper,
            IMediator mediator)
        {
            _signInManager = signInManager;

            _usersService = usersService;

            _mapper = mapper;

            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var users = _mapper.Map<List<UserViewModel>>(await _usersService.GetAllUsers());

            return View(new AdminPanelViewModel { Users = users });
        }

        [HttpPost]
        public async Task<JsonResult> DeleteBot(string botId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new DeleteBotCommand(botId));

                return Json(result);
            }
            return Json(new ResultActionModel(400, "Бот не найден!"));
        }

        [HttpPost]
        public async Task<JsonResult> AddBot(string userId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new AddBotCommand(userId));

                return Json(result);
            }
            return Json(new ResultActionModel(400, "Пользователь не найден!"));
        }
    }
}
