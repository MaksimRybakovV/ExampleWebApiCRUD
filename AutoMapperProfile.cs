using AutoMapper;
using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;

namespace ExampleWebApiCRUD
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Customer, GetCustomerDto>();
            CreateMap<AddCustomerDto, Customer>();
        }
    }
}
