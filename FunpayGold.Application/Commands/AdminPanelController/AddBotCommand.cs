using FunpayGold.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Commands.AdminPanelController
{
    public class AddBotCommand : IRequest<ResultActionModel>
    {

        public string UserId;

        public AddBotCommand(string userId)
        {
            UserId = userId;
        }

    }
}
