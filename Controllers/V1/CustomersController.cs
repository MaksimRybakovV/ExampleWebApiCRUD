using Asp.Versioning;
using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;
using ExampleWebApiCRUD.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApiCRUD.v1.Controllers
{
    [ApiController]
    [ApiVersion(1.0)]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> GetAll()
        {
            return Ok(await _service.GetAllCustomersAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> GetSingle(int id)
        {
            var response = await _service.GetCustomerByIdAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<ActionResult<PageServiceResponse<List<GetCustomerDto>>>> GetPage([FromQuery] int page, [FromQuery] int pageSize)
        {
            var response = await _service.GetCustomerByPageAsync(page, pageSize);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> PostCustomer(AddCustomerDto newCustomer)
        {
            return Ok(await _service.AddCustomerAsync(newCustomer));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<GetCustomerDto>>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            var response = await _service.UpdateCustomerAsync(updatedCustomer);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponse<List<GetCustomerDto>>>> DeleteCustomer(int id)
        {
            var response = await _service.DeleteCustomerAsync(id);

            if (response.Data is null)
                return NotFound(response);

            return Ok(response);
        }
    }
}
