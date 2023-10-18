using AutoMapper;
using ExampleWebApiCRUD.Data;
using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApiCRUD.Services.CustomerService
{
    public class CustomerService : BaseService, ICustomerService
    {
        public CustomerService(DataContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<ServiceResponce<List<GetCustomerDto>>> AddCustomerAsync(AddCustomerDto newCustomer)
        {
            var responce = new ServiceResponce<List<GetCustomerDto>>();
            await _context.Customers.AddAsync(_mapper.Map<Customer>(newCustomer));
            await _context.SaveChangesAsync();
            responce.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();
            return responce;
        }

        public async Task<ServiceResponce<List<GetCustomerDto>>> DeleteCustomerAsync(int id)
        {
            var responce = new ServiceResponce<List<GetCustomerDto>>();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Customer with Id '{id}' not found!");

                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();

                responce.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();
            }
            catch (Exception ex)
            {
                responce.IsSuccessful = false;
                responce.Message = ex.Message;
            }

            return responce;
        }

        public async Task<ServiceResponce<List<GetCustomerDto>>> GetAllCustomersAsync()
        {
            var responce = new ServiceResponce<List<GetCustomerDto>>();
            responce.Data = await _context.Customers.Select(c => _mapper.Map<GetCustomerDto>(c)).ToListAsync();
            return responce;
        }

        public async Task<ServiceResponce<GetCustomerDto>> GetCustomerByIdAsync(int id)
        {
            var responce = new ServiceResponce<GetCustomerDto>();
            
            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == id)
                    ?? throw new Exception($"Customer with Id '{id}' not found!");

                responce.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                responce.IsSuccessful = false;
                responce.Message = ex.Message;
            }

            return responce;
        }

        public async Task<ServiceResponce<GetCustomerDto>> UpdateCustomerAsync(UpdateCustomerDto updatedCustomer)
        {
            var responce = new ServiceResponce<GetCustomerDto>();

            try
            {
                var customer = await _context.Customers.SingleOrDefaultAsync(c => c.Id == updatedCustomer.Id)
                    ?? throw new Exception($"Customer with Id '{updatedCustomer.Id}' not found!");

                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.BirthDate = updatedCustomer.BirthDate;
                customer.Age = updatedCustomer.Age;
                customer.Address = updatedCustomer.Address;
                customer.Gender = updatedCustomer.Gender;

                await _context.SaveChangesAsync();

                responce.Data = _mapper.Map<GetCustomerDto>(customer);
            }
            catch (Exception ex)
            {
                responce.IsSuccessful = false;
                responce.Message = ex.Message;
            }

            return responce;
        }
    }
}
