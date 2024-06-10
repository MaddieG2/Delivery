using Delivery.APIService;
using Delivery.APIService.DTO;
using Delivery.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Delivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public DriverController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        [Route("GetDrivers")]
        public List<DriverAPIServiceDTO> GetDrivers()
        {
            DriverService myDriverSerive = new DriverService(_configuration);
            List<DriverAPIServiceDTO> myDrivers= myDriverSerive.GetDrivers();   
            
            return myDrivers;
        }
        
    }

   
}
