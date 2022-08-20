using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Services.Interfaces
{
    public interface IBotsService
    {

        public Task AddBot(string userId);

        public Task DeleteBotById(string botId);
    }
}
