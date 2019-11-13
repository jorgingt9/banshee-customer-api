using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _cityRepository.GetAll();
        }

        public async Task<IEnumerable<City>> GetById(int id)
        {
            return await _cityRepository.GetById(id);
        }
    }
}
