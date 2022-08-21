using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.CabinetController
{
    public class TurnOffBotCommand : IRequest<ResultActionModel>
    {

        public string BotId;

        public TurnOffBotCommand(string botId)
        {
            BotId = botId;
        }

    }
}
