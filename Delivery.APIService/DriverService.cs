using Delivery.APIService.DTO;
using Delivery.APIService.Extensions;
using Delivery.Repository;
using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Delivery.APIService
{
    public class DriverService
    {

        private readonly IConfiguration _configuration;

        public DriverService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<DriverAPIServiceDTO> GetDrivers()
        {
            RepositoryService driverSerive = new RepositoryService(_configuration);
            List<DriverRepositoryDTO> drivers = driverSerive.GetDrivers();
            return drivers.DriverRepositoryDTOsToAPIServiceDTOs();
        }
    } 
}
 