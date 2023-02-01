using FunpayGold.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Persistence.Repositories.Interfaces
{
    public interface IWorkersRepository
    {

        public Task<bool> IsRegistered(Guid id);

        public Task<WorkerEntity> GetWorker(Guid id);

        public Task<int> AddWorker(WorkerEntity entity);

        public Task<int> DeleteWorker(Guid id);

        public Task<int> UpdateWorker(WorkerEntity entity);

    }
}
