﻿using FunpayGold.Application.Commands.CabinetController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.CommandHandlers.CabinetController
{
    public class TurnOnBotCommandHandler : IRequestHandler<TurnOnBotCommand, ResultActionModel>
    {
        private readonly IBotsService _botsService;

        public TurnOnBotCommandHandler(IBotsService botsService)
        {
            _botsService = botsService;
        }

        public async Task<ResultActionModel> Handle(TurnOnBotCommand request, CancellationToken cancellationToken)
        {

            var bot = await _botsService.GetBotById(request.BotId);

            if(bot == null)
                return new ResultActionModel(400, $"Бот {request.BotId} не найден!");

            bot.IsActive = true;

            await _botsService.UpdateBot(bot);

            return new ResultActionModel(200, $"Бот {request.BotId} будет запущен в ближайшее время!");
        }

    }
}
