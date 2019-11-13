using AutoMapper;
using Banshee.Customers.Domain.Interfaces;
using Banshee.Customers.Domain.Settings;
using Banshee.Customers.Infraestructure.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Infraestructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMapper _mapper;
        private readonly IDb _db;
        private readonly IOptions<AppSettings> _settings;

        public CustomerRepository(IDb db, IMapper mapper, IOptions<AppSettings> settings)
        {
            _db = db;
            _mapper = mapper;
            _settings = settings;
        }
    }
}
