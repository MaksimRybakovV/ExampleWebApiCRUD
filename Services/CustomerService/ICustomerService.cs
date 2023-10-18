using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;

namespace ExampleWebApiCRUD.Services.CustomerService
{
    public interface ICustomerService
    {
        public Task<ServiceResponce<List<GetCustomerDto>>> GetAllCustomersAsync();
        public Task<ServiceResponce<GetCustomerDto>> GetCustomerByIdAsync(int id);
        public Task<ServiceResponce<List<GetCustomerDto>>> AddCustomerAsync(AddCustomerDto newCustomer);
        public Task<ServiceResponce<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer);
        public Task<ServiceResponce<List<GetCustomerDto>>> DeleteCustomerAsync(int id);
    }
}
