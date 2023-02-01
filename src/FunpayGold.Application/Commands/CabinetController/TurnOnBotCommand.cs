
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.CabinetController
{
    public class TurnOnBotCommand : IRequest<ResultActionModel>
    {

        public string BotId;

        public TurnOnBotCommand(string botId)
        {
            BotId = botId;
        }

    }
}
