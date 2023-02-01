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
    public class WorkersRepository : IWorkersRepository
    {

        private readonly FunpayGoldDbContext _db;

        public WorkersRepository(FunpayGoldDbContext db)
        {

            _db = db;
        }

        public async Task<bool> IsRegistered(Guid id)
        {
            var worker = await GetWorker(id);

            if (worker == null)
                return false;

            return true;
        }

        public async Task<WorkerEntity> GetWorker(Guid id)
        {
            var worker = await _db.Workers.Include(b=>b.Bots).Where(w => w.Id == id).FirstOrDefaultAsync();

            return worker;
        }

        public async Task<int> AddWorker(WorkerEntity entity)
        {
            await _db.Workers.AddAsync(entity);

            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int> DeleteWorker(Guid id)
        {
            var worker = await GetWorker(id);

            if (worker != null)
                _db.Workers.Remove(worker);

            var result = await _db.SaveChangesAsync();

            return result;
        }

        public async Task<int> UpdateWorker(WorkerEntity entity)
        {
            _db.ChangeTracker.Clear();

            _db.Workers.Update(entity);

            var result = await _db.SaveChangesAsync();

            return result;
        }
    }
}
