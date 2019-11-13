using Banshee.Customers.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Interfaces
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetById(int id);
        //Task<IEnumerable<State>> GetStateByCountryId(int id);
        Task<IEnumerable<State>> GetAll();
    }
}
