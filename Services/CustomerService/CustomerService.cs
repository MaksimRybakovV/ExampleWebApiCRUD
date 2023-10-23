using AutoMapper;
using ExampleWebApiCRUD.Data;
using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApiCRUD.Services.CustomerService
{
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        public CustomerService(DataContext context, IMapper mapper, ILogger<Customer> logger) : base(context, mapper, logger) { }

        public async Task<ServiceResponse<List<GetCustomerDto>>> AddCustomerAsync(AddCustomerDto newCustomer)
        {
            var response = new ServiceResponse<List<GetCustomerDto>>();
            await _context.Customers.AddAsync(_mapper.Map<Customer>(newCustomer));
            await _context.SaveChangesAsync();
            response.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();
            _logger.LogInformation("The object was created with the values {@newCustomer}.", newCustomer);
            return response;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> DeleteCustomerAsync(int id)
        {
            var response = new ServiceResponse<List<GetCustomerDto>>();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Customer with Id '{id}' not found!");

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                response.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();

                _logger.LogInformation("The object with ID '{id}' has been deleted.", id);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                _logger.LogError("The object with ID '{id}' not found.", id);
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetCustomerDto>>> GetAllCustomersAsync()
        {
            var response = new ServiceResponse<List<GetCustomerDto>>();
            response.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();
            return response;
        }

        public async Task<ServiceResponse<GetCustomerDto>> GetCustomerByIdAsync(int id)
        {
            var response = new ServiceResponse<GetCustomerDto>();
            
            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Customer with Id '{id}' not found!");

                response.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<PageServiceResponse<List<GetCustomerDto>>> GetCustomerByPageAsync(int page, int pageSize)
        {
            var response = new PageServiceResponse<List<GetCustomerDto>>();

            try
            {
                var pageCount = Math.Ceiling(_context.Customers.Count() / (float)pageSize);

                if (page > pageCount)
                    throw new Exception($"The page {page} does not exist. The maximum number of pages is {pageCount}.");

                var customers = await _context.Customers
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .Select(c => _mapper.Map<GetCustomerDto>(c))
                    .ToListAsync();

                response.Data = customers;
                response.CurrentPage = page;
                response.PageCount = (int)pageCount;
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer)
        {
            var response = new ServiceResponse<GetCustomerDto>();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == updatedCustomer.Id)
                    ?? throw new Exception($"Customer with Id '{updatedCustomer.Id}' not found!");

                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Age = updatedCustomer.Age;
                customer.Address = updatedCustomer.Address;
                customer.Gender = updatedCustomer.Gender;

                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetCustomerDto>(customer);

                _logger.LogInformation("The object with ID '{updatedCustomer.Id}' has been updated " +
                    "with values {@updatedCustomer}.", updatedCustomer.Id, updatedCustomer);
            }
            catch (Exception ex)
            {
                response.IsSuccessful = false;
                response.Message = ex.Message;
                _logger.LogError("The object with ID '{updatedCustomer.Id}' not found.", updatedCustomer.Id);
            }

            return response;
        }
    }
}
