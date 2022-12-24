using Service;

using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using EntityModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;


        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public Customer Get()
        {
            return _customerService.GetCustomer();
        }

        [HttpGet("GetAll")]
        public List<Customer> GetAll()
        {
            return _customerService.GetCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _customerService.Add(customer);

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return;

            _customerService.Edit(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
          //  _customerService.Delete(id);
        }
    }
}
