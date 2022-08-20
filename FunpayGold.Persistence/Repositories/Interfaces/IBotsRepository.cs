using FunpayGold.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Interfaces
{
    public interface IBotsRepository
    {

        public Task<IdentityResult> AddBotToUserById(string userId);

        public Task<int> DeleteBotById(string botId);

        public Task<int> CreateBot(BotEntity bot);

    }
}
