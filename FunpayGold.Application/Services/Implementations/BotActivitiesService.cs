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
    public class BotActivitiesService : IBotActivitiesService
    {
        private readonly IBotActivitiesRepository _botActivitiesRepository;

        private readonly IMapper _mapper;

        public BotActivitiesService(IBotActivitiesRepository botActivitiesRepository, IMapper mapper)
        {
            _botActivitiesRepository = botActivitiesRepository;

            _mapper = mapper;
        }

        public async Task<int> Create(BotActivityModel model)
        {

            var entity = _mapper.Map<BotActivityEntity>(model);

            var result = await _botActivitiesRepository.Create(entity);

            return result;
        }

        public async Task<BotActivityModel> GetById(string botActivityId)
        {
            var guid = new Guid(botActivityId);

            var entity = await _botActivitiesRepository.GetById(guid);

            var model = _mapper.Map<BotActivityModel>(entity);

            return model;
        }

        public async Task<int> DeleteById(string id)
        {
            var guid = new Guid(id);

            var result = await _botActivitiesRepository.DeleteById(guid);

            return result;
        }

    }
}
