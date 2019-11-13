using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
    }
}
