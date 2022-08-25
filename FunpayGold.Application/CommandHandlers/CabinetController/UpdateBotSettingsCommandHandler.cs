using AutoMapper;
using FunpayGold.Application.Commands.CabinetController;
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
    public class UpdateBotSettingsCommandHandler : IRequestHandler<UpdateBotSettingsCommand, ResultActionModel>
    {
        private readonly IBotsService _botsService;
        private readonly IMapper _mapper;

        public UpdateBotSettingsCommandHandler(IBotsService botsService,IMapper mapper)
        {
            _botsService = botsService;

            _mapper = mapper;
        }

        public async Task<ResultActionModel> Handle(UpdateBotSettingsCommand request, CancellationToken cancellationToken)
        {
            var botId = request.Bot.Id.ToString();

            var bot = await _botsService.GetBotById(botId);

            if (bot == null)
                return new ResultActionModel(400, $"Бот {botId} не найден!");

            await _botsService.UpdateBot(request.Bot);

            return new ResultActionModel(200, $"Настройки бота {botId} обновлены!");
        }

    }
}
