using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Queries.BotSettingsController
{
    public class GetAllMyBotsQuery : IRequest<ResultActionModel>
    {

        public string WorkerId;

        public GetAllMyBotsQuery(string workerId)
        {
            WorkerId = workerId;
        }

    }

}
