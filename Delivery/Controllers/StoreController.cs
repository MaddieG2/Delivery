using Delivery.APIService;
using Delivery.APIService.Models;
using Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Delivery.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public StoreController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetStoresByCity")]
        public List<string> GetStoresByCity(string city)
        {
            return new List<string> {""};
        }

        [HttpPost] //Create action - new resource is added. 
        [Route("RegisterStore")]
        public IActionResult RegisterStore([FromBody] StoreDetail storeDetails)
        {
            if(storeDetails.PhoneNumber == null)
            {
                return BadRequest("Phone number missing");
            }

            StoreService storeService = new StoreService(_configuration);

            storeService.RegisterStore(storeDetails);
            
            return Ok("Store Registered Successfully.");
        }        
    }
}