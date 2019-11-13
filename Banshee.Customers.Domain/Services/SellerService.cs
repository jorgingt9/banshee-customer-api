using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Banshee.Customers.Domain.Services
{
    public class SellerService : ISellerService
    {
        private readonly ISellerRepository _sellerRepository;
        public SellerService(ISellerRepository sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public async Task<IEnumerable<Seller>> GetAll()
        {
            return await _sellerRepository.GetAll();
        }

        public async Task<IEnumerable<Seller>> GetById(int id)
        {
            return await _sellerRepository.GetById(id);
        }
    }
}
