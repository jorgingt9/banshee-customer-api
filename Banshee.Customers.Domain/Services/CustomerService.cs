using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Exceptions;
using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Banshee.Customers.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _customerRepository.Delete(id);
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _customerRepository.GetAll();
        }

        public async Task<IEnumerable<Customer>> GetById(int id)
        {
            return await _customerRepository.GetById(id);
        }

        public async Task<bool> Save(Customer customer)
        {


            return await _customerRepository.Save(customer);
        }

        public async Task<bool> Update(Customer customer)
        {


            return await _customerRepository.Update(customer);
        }

        public async Task<IEnumerable<Customer>> ValidateCustomer(int id)
        {
            var customer = await _customerRepository.GetById(id);

            if (customer == null || customer.Count() == 0)
            {
                throw new CustomerNotFoundException($"Customer id: { id } not found");
            }

            return customer;
        }
    }
}
