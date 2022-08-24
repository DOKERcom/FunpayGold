using AutoMapper;
using FunpayGold.Application.Queries.BotSettingsController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.QueryHandlers.BotSettingsController
{
    public class GetAllMyBotsQueryHandler : IRequestHandler<GetAllMyBotsQuery, ResultActionModel>
    {

        private readonly IWorkersService _workersService;

        private readonly IBotsService _botsService;

        private readonly IMapper _mapper;

        public GetAllMyBotsQueryHandler(IWorkersService workersService, IBotsService botsService, IMapper mapper)
        {
            _workersService = workersService;

            _botsService = botsService;

            _mapper = mapper;
        }

        public async Task<ResultActionModel> Handle(GetAllMyBotsQuery request, CancellationToken cancellationToken)
        {

            var worker = await _workersService.GetWorker(request.WorkerId);

            ResultActionModel resultActionModel = new ResultActionModel();

            foreach(var bot in worker.Bots)
            {
                bot.Worker = null;
            }

            resultActionModel.ResultObject = worker.Bots;

            return resultActionModel;
        }
    }
}
