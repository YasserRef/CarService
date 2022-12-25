using Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using EntityModel;


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
        public Customer Find(string cusomerName)
        {
            return _customerService.Find_With_Text(cusomerName);
        }

        [HttpGet("GetById")]
        public dynamic Get(int id)
        {
            return _customerService.AsQueryable_Single(id);
        }       

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] Customer customer)
        {
            _ = _customerService.InsertOneAsync(customer);

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
                return;

            _customerService.UpdateOne(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _ = _customerService.DeleteOneAsync_With_Id(id);
        }
    }
}
