using FunpayGold.Application.Models;
using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.HomeController
{
    public class RegisterCommand : IRequest<ResultActionModel>
    {

        public RegisterModel RegisterModel;

        public RegisterCommand(RegisterModel registerModel)
        {
            RegisterModel = registerModel;
        }

    }
}
