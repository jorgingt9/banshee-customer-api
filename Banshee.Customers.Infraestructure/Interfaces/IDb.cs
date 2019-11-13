using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Infraestructure.Interfaces
{
    public interface IDb
    {
        void MigrateDataBase();
        Task<IList<T>> SelectAsync<T>(string sql, object parameters);
        Task<T> GetAsync<T>(string sql, object parameters);
        Task<T> GetFistAsync<T>(string sql, object parameters);
        Task ExecuteAsync(string sql, object parameters);
    }
}
