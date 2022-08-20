using FunpayGold.Persistence.DbContexts;
using FunpayGold.Persistence.Entities;
using FunpayGold.Persistence.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Implementations
{
    public class BotsRepository : IBotsRepository
    {

        private readonly UserManager<UserEntity> _userManager;

        private readonly IUsersRepository _usersRepository;

        private readonly FunpayGoldDbContext _db;

        public BotsRepository(UserManager<UserEntity> userManager, FunpayGoldDbContext db, IUsersRepository usersRepository)
        {
            _userManager = userManager;

            _usersRepository = usersRepository;

            _db = db;
        }

        public async Task<int> CreateBot(BotEntity bot)
        {
 
            await _db.Bots.AddAsync(bot);

            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<IdentityResult> AddBotToUserById(string userId)
        {
            var bot = new BotEntity();

            await CreateBot(bot);

            var user =  await _userManager.Users.Include(b => b.Bots).Where(u => u.Id == userId).FirstOrDefaultAsync();

            var prevBot = await _db.Bots.Where(b => b.Id == bot.Id).FirstOrDefaultAsync();

            if (user != null && prevBot != null)
                user.Bots.Add(prevBot);

            var result = await _usersRepository.UpdateUser(user);

            return result;
        }


        public async Task<int> DeleteBotById(string botId)
        {
            Guid botIdGuid = new Guid(botId);

            var bot = await _db.Bots.Where(b => b.Id == botIdGuid).FirstOrDefaultAsync();

            if (bot != null)
                _db.Bots.Remove(bot);

            var result = await _db.SaveChangesAsync();

            return result;
        }
    }
}
