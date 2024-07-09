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
using System.Linq;

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
            if (storeDetails.PhoneNumber == null)
            {
                return BadRequest("Phone number missing");
            }

            StoreService storeService = new StoreService(_configuration);

            storeService.RegisterStore(storeDetails);

            return Ok("Store Registered Successfully.");
        }

        [HttpDelete]
        [Route("DeleteStore")]
        public IActionResult DeleteStore(Guid id)
        {
            StoreService storeService = new StoreService(_configuration);

            List<StoreDetailAPIServiceDTO> stores = storeService.GetStores();

            bool doesStoreExist = stores.Any(st => st.StoreId == id);

            if (!doesStoreExist)
            {
                return BadRequest("ID does not exist");
            }

            bool isStoreDeleted = storeService.DeleteStore(id);

            return Ok($"Store Deleted: {isStoreDeleted}");
        }

        [HttpPut]
        [Route("UpdateStore")]
        public IActionResult UpdateStore( [FromBody] StoreDetail storeDetail)
        {
            StoreService storeService = new StoreService(_configuration);

            if (storeDetail == null)
            {
                return BadRequest("Invalid Detail");
            }
            List<StoreDetailAPIServiceDTO> stores = storeService.GetStores();
            bool doesStoreExist = stores.Any(st => st.StoreId == storeDetail.StoreId);

            if (!doesStoreExist)
            {
                return BadRequest("store does not exist");
            }

            var UpdatedResult = storeService.UpdateStore(storeDetail);

            if (!UpdatedResult)
            {
                return StatusCode(500, "An error occurred while updating the store");
            }

            return Ok("Store Updated ");

        }
    }
}

