using FunpayGold.Application.Commands.CabinetController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.CommandHandlers.CabinetController
{
    public class TurnOffBotCommandHandler : IRequestHandler<TurnOffBotCommand, ResultActionModel>
    {
        private readonly IBotsService _botsService;

        public TurnOffBotCommandHandler(IBotsService botsService)
        {
            _botsService = botsService;
        }

        public async Task<ResultActionModel> Handle(TurnOffBotCommand request, CancellationToken cancellationToken)
        {

            var bot = await _botsService.GetBotById(request.BotId);

            if (bot == null)
                return new ResultActionModel(400, $"Бот {request.BotId} не найден!");

            bot.IsActive = false;

            await _botsService.UpdateBot(bot);

            return new ResultActionModel(200, $"Бот {request.BotId} будет выключен в ближайшее время!");
        }

    }
}
