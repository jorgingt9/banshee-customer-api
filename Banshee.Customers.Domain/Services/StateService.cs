using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;
        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            return await _stateRepository.GetAll();
        }

        public async Task<IEnumerable<State>> GetById(int id)
        {
            return await _stateRepository.GetById(id);
        }
    }
}
