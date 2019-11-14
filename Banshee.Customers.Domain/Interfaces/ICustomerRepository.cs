using Banshee.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetById(int id);
        Task<IEnumerable<Customer>> GetAll();
        Task<bool> Save(Customer customer);
        Task<bool> Update(Customer customer);
        Task<bool> Delete(int id);
    }
}
