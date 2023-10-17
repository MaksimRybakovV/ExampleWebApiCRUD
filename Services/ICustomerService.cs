using ExampleWebApiCRUD.Entities.Dtos.Customer;
using ExampleWebApiCRUD.Entities.Models;

namespace ExampleWebApiCRUD.Services
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
