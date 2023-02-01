using AutoMapper;
using FunpayGold.Application.Commands.BotSettingsController;
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
    public class GetNewBotCommandHandler : IRequestHandler<GetNewBotCommand, ResultActionModel>
    {

        private readonly IWorkersService _workersService;

        private readonly IBotsService _botsService;

        private readonly IMapper _mapper;

        public GetNewBotCommandHandler(IWorkersService workersService, IBotsService botsService, IMapper mapper)
        {
            _workersService = workersService;

            _botsService = botsService;

            _mapper = mapper;
        }

        public async Task<ResultActionModel> Handle(GetNewBotCommand request, CancellationToken cancellationToken)
        {

            var bots = await _botsService.GetAllActiveFreeBots();

            if (bots.Count == 0)
                return new ResultActionModel(400);

            var bot = bots.First();

            var worker = await _workersService.GetWorker(request.WorkerId);

            worker.Bots.Add(bot);

            await _workersService.UpdateWorker(worker);

            var resultGetNewBotModel = new ResultActionModel();

            resultGetNewBotModel.ResultObject = bot;

            return resultGetNewBotModel;
        }
    }
}
