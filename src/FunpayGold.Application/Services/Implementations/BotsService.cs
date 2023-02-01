using AutoMapper;
using FunpayGold.Application.Models;
using FunpayGold.Application.Services.Interfaces;
using FunpayGold.Persistence.Entities;
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

        private readonly IMapper _mapper;

        public BotsService(IBotsRepository botsRepository, IMapper mapper)
        {
            _botsRepository = botsRepository;

            _mapper = mapper;
        }

        public async Task<List<BotModel>> GetAllActiveFreeBots()
        {
            var bots = await _botsRepository.GetAllActiveFreeBots();

            var botModels = _mapper.Map<List<BotModel>>(bots);

            return botModels;
        }

        public async Task AddBotToUserById(string userId)
        {
            await _botsRepository.AddBotToUserById(userId);
        }

        public async Task DeleteBotById(string botId)
        {
            await _botsRepository.DeleteBotById(new Guid(botId));
        }

        public async Task<BotModel?> GetBotById(string botId)
        {
            var botEntity = await _botsRepository.GetBotById(new Guid(botId));

            var bot = _mapper.Map<BotModel>(botEntity);

            return bot;
        }

        public async Task<int> CreateBot()
        {
            var bot = new BotModel();

            var botEntity = _mapper.Map<BotEntity>(bot);

            var result = await _botsRepository.CreateBot(botEntity);

            return result;
        }

        public async Task<int> UpdateBot(BotModel bot)
        {
            var botEntity = _mapper.Map<BotEntity>(bot);

            var result = await _botsRepository.UpdateBot(botEntity);

            return result;
        }


    }
}
