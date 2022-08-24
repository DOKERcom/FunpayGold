using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.BotSettingsController
{
    public class RegisterWorkerCommand : IRequest<ResultActionModel>
    {

        public string WorkerId;

        public RegisterWorkerCommand(string workerId)
        {
            WorkerId = workerId;
        }

    }
}
