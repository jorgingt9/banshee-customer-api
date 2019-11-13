using Banshee.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Interfaces
{
    public interface ISellerService
    {
        Task<IEnumerable<Seller>> GetById(int id);
        Task<IEnumerable<Seller>> GetAll();
    }
}
