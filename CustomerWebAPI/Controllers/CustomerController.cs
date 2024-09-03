using CustomerWebAPI.Models;
using CustomerWebAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CustomerWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        // POST: api/customers
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            int id = _customerRepository.CreateCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id }, customer);
        }

        // GET: api/customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return Ok(_customerRepository.GetCustomers());
        }

        // GET: api/customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return Ok(_customerRepository.GetCustomer(id));
        }

        // PUT: api/customers
        [HttpPut]
        public async Task<ActionResult<Customer>> PutCustomer(Customer customer)
        {
            if (customer == null || customer.Id < 0)
            {
                return BadRequest();
            }

            _customerRepository.UpdateCustomer(customer);

            return CreatedAtAction(nameof(GetCustomer), new { id = customer.Id }, customer);
        }

        // DELETE: api/customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            _customerRepository.DeleteCustomer(id);

            return NoContent();
        }

    }
}
