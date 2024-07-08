using Delivery.APIService;
using Delivery.APIService.DTO;
using Delivery.APIService.Models;
using Delivery.Models;
using Delivery.Repository.DTO;
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
        [Route("GetStores")]
        public List<StoreDetailAPIServiceDTO> GetStores(string city = "")
        {
           StoreService storeService = new StoreService(_configuration);
           List<StoreDetailAPIServiceDTO> stores = storeService.GetStores(city);

           return stores;
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