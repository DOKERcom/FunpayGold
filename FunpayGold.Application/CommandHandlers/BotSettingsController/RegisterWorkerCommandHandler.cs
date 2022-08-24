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
    public class RegisterWorkerCommandHandler : IRequestHandler<RegisterWorkerCommand, ResultActionModel>
    {

        private readonly IWorkersService _workersService;

        private readonly IBotsService _botsService;

        private readonly IMapper _mapper;

        public RegisterWorkerCommandHandler(IWorkersService workersService, IBotsService botsService, IMapper mapper)
        {
            _workersService = workersService;

            _botsService = botsService;

            _mapper = mapper;
        }

        public async Task<ResultActionModel> Handle(RegisterWorkerCommand request, CancellationToken cancellationToken)
        {

            if (await _workersService.IsRegistered(request.WorkerId))
                return new ResultActionModel();

            try 
            {
                new Guid(request.WorkerId);
            }
            catch
            {
                return new ResultActionModel(500);
            }

            await _workersService.AddWorker(new WorkerModel(new Guid(request.WorkerId)));

            return new ResultActionModel();
        }

    }
}
