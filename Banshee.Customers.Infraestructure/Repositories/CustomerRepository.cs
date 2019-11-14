using AutoMapper;
using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using Banshee.Customers.Domain.Settings;
using Banshee.Customers.Infraestructure.DataModels;
using Banshee.Customers.Infraestructure.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<bool> Delete(int id)
        {
            await _db.ExecuteAsync("DELETE FROM dbo.Customers WHERE Id = @id", new { Id = id});
            return true;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            var sql = @"SELECT CU.Id,
                        CU.Nit, 
                        CU.Name, 
                        CU.Address, 
                        CU.Telephone, 
                        CU.CityId, 
                        CI.Name AS City,
                        CU.StateId, 
                        ST.Name AS State,
                        CU.CountryId, 
                        CO.Name AS Country,
                        CU.CreditLimit, 
                        CU.AvalaibleCredit, 
                        CU.VisitsPercentage, 
                        SE.Name AS Seller
                        FROM dbo.Customers CU INNER JOIN dbo.Countries CO ON
                        CU.CountryId = CO.Id INNER JOIN dbo.States ST ON
                        CU.StateId = ST.Id INNER JOIN dbo.Cities CI ON
                        CU.CityId = CI.Id INNER JOIN dbo.Sellers SE ON
                        CU.SellerId = SE.Id";

            var response = await _db.SelectAsync<CustomerDataModel>(sql, new { });

            return _mapper.Map<IEnumerable<Customer>>(response);
        }

        public async Task<IEnumerable<Customer>> GetById(int id)
        {
            var sql = @"SELECT CU.Id,
                        CU.Nit, 
                        CU.Name, 
                        CU.Address, 
                        CU.Telephone, 
                        CU.CityId, 
                        CI.Name AS City,
                        CU.StateId, 
                        ST.Name AS State,
                        CU.CountryId, 
                        CO.Name AS Country,
                        CU.CreditLimit, 
                        CU.AvalaibleCredit, 
                        CU.VisitsPercentage, 
                        SE.Name AS Seller
                        FROM dbo.Customers CU INNER JOIN dbo.Countries CO ON
                        CU.CountryId = CO.Id INNER JOIN dbo.States ST ON
                        CU.StateId = ST.Id INNER JOIN dbo.Cities CI ON
                        CU.CityId = CI.Id INNER JOIN dbo.Sellers SE ON
                        CU.SellerId = SE.Id
                        WHERE CU.Id = @Id";

            var response = await _db.SelectAsync<CustomerDataModel>(sql, new { Id = id });

            return _mapper.Map<IEnumerable<Customer>>(response);
        }

        public async Task<bool> Save(Customer customer)
        {
            var sql = @"INSERT INTO dbo.Customers(Nit, Name, Address, Telephone, CityId, StateId, CountryId, CreditLimit, AvalaibleCredit, VisitsPercentage, SellerId)
                        VALUES(@Nit, @Name, @Address, @Telephone, @CityId, @StateId, @CountryId, @CreditLimit, @AvalaibleCredit, @VisitsPercentage, @SellerId)";

            await _db.ExecuteAsync(sql, customer);

            return true;
        }

        public async Task<bool> Update(Customer customer)
        {
            var sql = @"UPDATE dbo.Customers
                        SET Nit = @Nit,
                        Name = @Name,
                        Address = @Address,
                        Telephone = @Telephone,
                        CityId = @CityId,
                        StateId = @StateId,
                        CountryId = @CountryId,
                        CreditLimit = @CreditLimit,
                        AvalaibleCredit = @AvalaibleCredit,
                        VisitsPercentage = @VisitsPercentage,
                        SellerId = @SellerId
                        WHERE Id=@Id";

            await _db.ExecuteAsync(sql, customer);

            return true;
        }
    }
}
