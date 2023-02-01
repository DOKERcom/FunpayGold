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
        public Task<List<BotEntity>> GetAllActiveFreeBots();

        public Task<IdentityResult> AddBotToUserById(string userId);

        public Task<int> DeleteBotById(Guid botId);

        public Task<int> CreateBot(BotEntity bot);

        public Task<int> UpdateBot(BotEntity bot);

        public Task<BotEntity?> GetBotById(Guid botId);

    }
}
