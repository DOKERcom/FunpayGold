using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Persistence.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Services.Implementations
{
    public class BotsService : IBotsService
    {

        private readonly IBotsRepository _botsRepository;

        public BotsService(IBotsRepository botsRepository)
        {
            _botsRepository = botsRepository;
        }

        public async Task AddBot(string userId)
        {
            await _botsRepository.AddBotToUserById(userId);
        }

        public async Task DeleteBotById(string botId)
        {
            await _botsRepository.DeleteBotById(botId);
        }
    }
}
