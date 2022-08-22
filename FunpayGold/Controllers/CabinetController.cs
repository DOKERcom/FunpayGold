using AutoMapper;
using FunpayGold.Application.Commands.CabinetController;
using FunpayGold.Application.Models;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.MVC.ViewModels;
using FunpayGold.Persistence.Entities;
using MediatR;
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

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;
        public CabinetController(SignInManager<UserEntity> signInManager, IUsersService usersService, IMapper mapper, IMediator mediator)
        {
            _signInManager = signInManager;

            _usersService = usersService;

            _mapper = mapper;

            _mediator = mediator;
        }


        public async Task<IActionResult> Index()
        {
            string userName = HttpContext.User.Identity.Name;

            if (!string.IsNullOrEmpty(userName))
            {
                var user = _mapper.Map<UserViewModel>(await _usersService.GetUserByUserName(userName));

                return View(new CabinetViewModel { User = user });
            }

            return await Logout();
        }

        [HttpPost]
        public async Task<JsonResult> TurnOnBot(string botId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new TurnOnBotCommand(botId));

                return Json(result);
            }
            return Json(400, "Бот был не найден!");
        }

        [HttpPost]
        public async Task<JsonResult> TurnOffBot(string botId)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(new TurnOffBotCommand(botId));

                return Json(result);
            }
            return Json(400, "Бот был не найден!");
        }

        [HttpPost]
        public async Task<JsonResult> UpdateBotSettings(BotViewModel bot)
        {
            if (ModelState.IsValid)
            {
                var botModel = _mapper.Map<BotModel>(bot);

                botModel.Id = new Guid(bot.Id);

                var result = await _mediator.Send(new UpdateBotSettingsCommand(botModel));

                return Json(result);
            }
            return Json(400, "Бот был не найден!");
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
