using Delivery.APIService.DTO;
using Delivery.APIService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Delivery.Models;      

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CustomerController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetCustomers")]
        public List<CustomerAPIServiceDTO> GetCustomers()
        {
            CustomerService myCustomerSerive = new CustomerService(_configuration);
            List<CustomerAPIServiceDTO> myCustomers = myCustomerSerive.GetCustomers();

            return myCustomers;
        }
        [HttpPost]
        [Route("AddCustomers")]
        public IActionResult AddCustomers([FromBody] CustomerAPIServiceDTO newCustomer)
        {
            if(newCustomer == null)
            {
                return BadRequest("Invalid Customer data");
            }
           

            return Ok("Customer added successfully");
        }
    }
}
