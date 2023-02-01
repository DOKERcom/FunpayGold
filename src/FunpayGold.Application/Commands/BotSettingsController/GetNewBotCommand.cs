using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.BotSettingsController
{
    public class GetNewBotCommand : IRequest<ResultActionModel>
    {

        public string WorkerId;

        public GetNewBotCommand(string workerId)
        {
            WorkerId = workerId;
        }

    }
}
