using FunpayGold.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Services.Interfaces
{
    public interface IBotActivitiesService
    {

        public Task<int> Create(BotActivityModel model);

        public Task<int> DeleteById(string id);

        public Task<BotActivityModel> GetById(string botActivityId);

    }
}
