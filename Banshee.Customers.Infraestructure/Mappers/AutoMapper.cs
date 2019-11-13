using AutoMapper;
using Banshee.Customers.Domain.Entities;
using Banshee.Customers.Infraestructure.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Banshee.Customers.Infraestructure.Mappers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Country, CountryDataModel>().ReverseMap();
            CreateMap<State, StateDataModel>().ReverseMap();
            CreateMap<City, CityDataModel>().ReverseMap();
            CreateMap<Seller, SellerDataModel>().ReverseMap();
            CreateMap<Customer, CustomerDataModel>().ReverseMap();
        }
    }
}
