using FunpayGold.Persistence.DbContexts;
using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Implementations
{
    public class BotActivitiesRepository : IBotActivitiesRepository
    {

        private readonly FunpayGoldDbContext _db;

        public BotActivitiesRepository(FunpayGoldDbContext db)
        {

            _db = db;
        }

        public async Task<int> Create(BotActivityEntity botActivityEntity)
        {
            _db.ChangeTracker.Clear();

            await _db.BotActivities.AddAsync(botActivityEntity);

            var result = await _db.SaveChangesAsync();

            return result;

        }

        public async Task<BotActivityEntity> GetById(Guid botActivityId)
        {
            var botActivity = await _db.BotActivities.Where(b => b.Id == botActivityId).FirstOrDefaultAsync();

            return botActivity;
        }

        public async Task<int> DeleteById(Guid id)
        {
            
            var botActivity = await _db.BotActivities.SingleOrDefaultAsync(x => x.Id == id);

            if(botActivity == null)
                return -1;

            _db.BotActivities.Remove(botActivity);

            var result = await _db.SaveChangesAsync();

            return result;
        }

    }
}
