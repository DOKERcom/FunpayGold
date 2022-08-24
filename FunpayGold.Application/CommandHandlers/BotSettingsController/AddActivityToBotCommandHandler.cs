using AutoMapper;
using FunpayGold.Application.Commands.BotSettingsController;
using FunpayGold.Application.Models;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.CommandHandlers.BotSettingsController
{
    public class AddActivityToBotCommandHandler : IRequestHandler<AddActivityToBotCommand, ResultActionModel>
    {

        private readonly IBotActivitiesService _botActivitiesService;

        private readonly IBotsService _botsService;

        private readonly IMapper _mapper;

        public AddActivityToBotCommandHandler(IBotActivitiesService botActivitiesService, IBotsService botsService, IMapper mapper)
        {
            _botActivitiesService = botActivitiesService;

            _botsService = botsService;

            _mapper = mapper;
        }

        public async Task<ResultActionModel> Handle(AddActivityToBotCommand request, CancellationToken cancellationToken)
        {

            var model = new BotActivityModel();

            model.Message = request.BotActivityQuery.Message;

            await _botActivitiesService.Create(model);

            var bot = await _botsService.GetBotById(request.BotActivityQuery.BotId);

            if (bot == null)
                return new ResultActionModel(400);

            bot.BotActivities.Add(model);

            await _botsService.UpdateBot(bot);

            return new ResultActionModel();
        }

    }
}
