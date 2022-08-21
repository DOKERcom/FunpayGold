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
    public class AddBotCommandHandler : IRequestHandler<AddBotCommand, ResultActionModel>
    {
        private readonly IBotsService _botsService;

        public AddBotCommandHandler(IBotsService botsService)
        {
            _botsService = botsService;
        }

        public async Task<ResultActionModel> Handle(AddBotCommand request, CancellationToken cancellationToken)
        {

            await _botsService.AddBotToUserById(request.UserId);

            return new ResultActionModel(200, $"Бот был добавлен к пользователю {request.UserId}!");
        }
    }
}
