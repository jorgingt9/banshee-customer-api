using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _countryRepository.GetAll();
        }

        public async Task<IEnumerable<Country>> GetById(int id)
        {
            return await _countryRepository.GetById(id);
        }
    }
}
