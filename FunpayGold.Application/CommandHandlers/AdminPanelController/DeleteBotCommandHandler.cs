using FunpayGold.Application.Commands.AdminPanelController;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.CommandHandlers.AdminPanelController
{
    public class DeleteBotCommandHandler : IRequestHandler<DeleteBotCommand, ResultActionModel>
    {
        private readonly IBotsService _botsService;

        public DeleteBotCommandHandler(IBotsService botsService)
        {
            _botsService = botsService;
        }

        public async Task<ResultActionModel> Handle(DeleteBotCommand request, CancellationToken cancellationToken)
        {

            await _botsService.DeleteBotById(request.BotId);

            return new ResultActionModel(200, $"Бот {request.BotId} был удалён!");
        }

    }
}
