
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.AdminPanelController
{
    public class DeleteBotCommand : IRequest<ResultActionModel>
    {

        public string BotId;

        public DeleteBotCommand(string botId)
        {
            BotId = botId;
        }

    }
}
