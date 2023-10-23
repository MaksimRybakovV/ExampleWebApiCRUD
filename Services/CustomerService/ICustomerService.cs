using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;

namespace ExampleWebApiCRUD.Services.CustomerService
{
    public interface ICustomerService
    {
        public Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomersAsync();
        public Task<ServiceResponse<GetCustomerDto>> GetCustomerByIdAsync(int id);
        public Task<PageServiceResponse<List<GetCustomerDto>>> GetCustomerByPageAsync(int page, int pageSize);
        public Task<ServiceResponse<List<GetCustomerDto>>> AddCustomerAsync(AddCustomerDto newCustomer);
        public Task<ServiceResponse<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer);
        public Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomerAsync(int id);
    }
}
