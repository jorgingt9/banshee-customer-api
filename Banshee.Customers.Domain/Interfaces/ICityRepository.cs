using Banshee.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Interfaces
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetById(int id);
        //Task<IEnumerable<City>> GetStateByStateId(int id);
        Task<IEnumerable<City>> GetAll();
    }
}
