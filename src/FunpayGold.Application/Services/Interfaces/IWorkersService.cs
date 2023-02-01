using FunpayGold.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunpayGold.Application.Services.Interfaces
{
    public interface IWorkersService
    {

        public Task<bool> IsRegistered(string id);

        public Task<WorkerModel> GetWorker(string id);

        public Task<int> AddWorker(WorkerModel model);

        public Task<int> DeleteWorker(string id);
            
        public Task<int> UpdateWorker(WorkerModel model);
        
    }
}
