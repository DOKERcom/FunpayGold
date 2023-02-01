using FunpayGold.Common.QueryModels;
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.BotSettingsController
{
    public class AddActivityToBotCommand : IRequest<ResultActionModel>
    {

        public BotActivityQueryModel BotActivityQuery;

        public AddActivityToBotCommand(BotActivityQueryModel botActivityQuery)
        {
            BotActivityQuery = botActivityQuery;
        }

    }
}
