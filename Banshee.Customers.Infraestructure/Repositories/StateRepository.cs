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
    public class StateRepository : IStateRepository
    {
        private readonly IMapper _mapper;
        private readonly IDb _db;
        private readonly IOptions<AppSettings> _settings;

        public StateRepository(IDb db, IMapper mapper, IOptions<AppSettings> settings)
        {
            _db = db;
            _mapper = mapper;
            _settings = settings;
        }

        public async Task<IEnumerable<State>> GetAll()
        {
            var response = await _db.SelectAsync<StateDataModel>("SELECT Id, Name FROM BansheeBD.dbo.States ORDER BY Id", new { });

            return _mapper.Map<IEnumerable<State>>(response);
        }

        public async Task<IEnumerable<State>> GetById(int id)
        {
            var sql = @"SELECT Id, Name FROM BansheeBD.dbo.States 
                        WHERE Id = @Id";

            var response = await _db.SelectAsync<StateDataModel>(sql, new { Id = id });

            return _mapper.Map<IEnumerable<State>>(response);
        }
    }
}
