using FunpayGold.Application.Models;
using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.CabinetController
{
    public class UpdateBotSettingsCommand : IRequest<ResultActionModel>
    {

        public BotModel Bot;

        public UpdateBotSettingsCommand(BotModel bot)
        {
            Bot = bot;
        }

    }
}
