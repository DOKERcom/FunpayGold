using FunpayGold.Application.Models;
using FunpayGold.Common.ResultModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.HomeController
{
    public class SignInCommand : IRequest<ResultActionModel>
    {

        public SignInModel SignInModel;

        public SignInCommand(SignInModel signInModel)
        {
            SignInModel = signInModel;
        }

    }
}
