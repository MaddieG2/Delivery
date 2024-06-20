using Delivery.APIService.DTO;
using Delivery.Repository.DTO;
using Delivery.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using Delivery.APIService.Extensions;

namespace Delivery.APIService
{
    public class CustomerService
    {
        private readonly IConfiguration _configuration;

        public CustomerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CustomerAPIServiceDTO> GetCustomers()
        {
            CustomerRepositoryService customerServiceRepository = new CustomerRepositoryService(_configuration);
            List<CustomerRepositoryDTO> customers = customerServiceRepository.GetCustomers();  
            return customers.CustomerRepositoryDTOsToCustomerAPIServiceDTOs();
        }
    }
}
