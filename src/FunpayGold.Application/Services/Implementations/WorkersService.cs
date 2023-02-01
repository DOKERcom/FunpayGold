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
    public class WorkersService : IWorkersService
    {

        private readonly IWorkersRepository _workersRepository;

        private readonly IMapper _mapper;

        public WorkersService(IWorkersRepository workersRepository, IMapper mapper)
        {
            _workersRepository = workersRepository;

            _mapper = mapper;
        }
        public async Task<bool> IsRegistered(string id)
        {
            var result = await _workersRepository.IsRegistered(new Guid(id));

            return result;
        }

        public async Task<WorkerModel> GetWorker(string id)
        {
            var workerEtity = await _workersRepository.GetWorker(new Guid(id));

            var worker = _mapper.Map<WorkerModel>(workerEtity);

            return worker;
        }

        public async Task<int> AddWorker(WorkerModel model)
        {
            var entity = _mapper.Map<WorkerEntity>(model);

            var result = await _workersRepository.AddWorker(entity);

            return result;
        }

        public async Task<int> DeleteWorker(string id)
        {
            var result = await _workersRepository.DeleteWorker(new Guid(id));

            return result;
        }

        public async Task<int> UpdateWorker(WorkerModel model)
        {
            var entity = _mapper.Map<WorkerEntity>(model);

            var result = await _workersRepository.UpdateWorker(entity);

            return result;
        }

    }
}
