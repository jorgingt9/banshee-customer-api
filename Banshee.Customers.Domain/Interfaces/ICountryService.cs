using Banshee.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetById(int id);
        Task<IEnumerable<Country>> GetAll();
    }
}
