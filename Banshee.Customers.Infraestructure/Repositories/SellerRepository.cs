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
    public class SellerRepository : ISellerRepository
    {
        private readonly IMapper _mapper;
        private readonly IDb _db;
        private readonly IOptions<AppSettings> _settings;

        public SellerRepository(IDb db, IMapper mapper, IOptions<AppSettings> settings)
        {
            _db = db;
            _mapper = mapper;
            _settings = settings;
        }

        public async Task<IEnumerable<Seller>> GetAll()
        {
            var response = await _db.SelectAsync<SellerDataModel>("SELECT Id, Name FROM BansheeBD.dbo.Sellers ORDER BY Id", new { });

            return _mapper.Map<IEnumerable<Seller>>(response);
        }

        public async Task<IEnumerable<Seller>> GetById(int id)
        {
            var sql = @"SELECT Id, Name FROM BansheeBD.dbo.Sellers 
                        WHERE Id = @Id";

            var response = await _db.SelectAsync<SellerDataModel>(sql, new { Id = id });

            return _mapper.Map<IEnumerable<Seller>>(response);
        }
    }
}
