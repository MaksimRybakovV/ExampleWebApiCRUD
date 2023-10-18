using ExampleWebApiCRUD.Entities.Dtos.CustomerDtos;
using ExampleWebApiCRUD.Entities.Models;
using ExampleWebApiCRUD.Services.CustomerService;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;

        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponce<List<GetCustomerDto>>>> GetAll()
        {
            return Ok(await _service.GetAllCustomersAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponce<GetCustomerDto>>> GetSingle([FromQuery]int id)
        {
            var responce = await _service.GetCustomerByIdAsync(id);

            if (responce.Data is null)
                return NotFound(responce);

            return Ok(responce);
        }

        [HttpGet]
        [Route("pagination")]
        public async Task<ActionResult<PageServiceResponce<List<GetCustomerDto>>>> GetPage([FromQuery] int page, [FromQuery] int pageSize)
        {
            var responce = await _service.GetCustomerByPageAsync(page, pageSize);

            if (responce.Data is null)
                return NotFound(responce);

            return Ok(responce);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponce<List<GetCustomerDto>>>> PostCustomer(AddCustomerDto newCustomer)
        {
            return Ok(await _service.AddCustomerAsync(newCustomer));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponce<GetCustomerDto>>> UpdateCustomer(UpdateCustomerDto updatedCustomer)
        {
            var responce = await _service.UpdateCustomerAsync(updatedCustomer);

            if (responce.Data is null)
                return NotFound(responce);

            return Ok(responce);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<ServiceResponce<List<GetCustomerDto>>>> DeleteCustomer(int id)
        {
            var responce = await _service.DeleteCustomerAsync(id);

            if (responce.Data is null)
                return NotFound(responce);

            return Ok(responce);
        }
    }
}
