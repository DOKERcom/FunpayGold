using FunpayGold.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Interfaces
{
    public interface IBotActivitiesRepository
    {

        public Task<int> Create(BotActivityEntity botActivityEntity);

        public Task<int> DeleteById(Guid id);

        public Task<BotActivityEntity> GetById(Guid botActivityId);

    }
}
