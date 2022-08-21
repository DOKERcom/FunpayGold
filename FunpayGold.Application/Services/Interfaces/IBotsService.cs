using FunpayGold.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Services.Interfaces
{
    public interface IBotsService
    {

        public Task AddBotToUserById(string userId);

        public Task DeleteBotById(string botId);

        public Task<int> CreateBot();

        public Task<int> UpdateBot(BotModel bot);

        public Task<BotModel?> GetBotById(string botId);
    }
}
