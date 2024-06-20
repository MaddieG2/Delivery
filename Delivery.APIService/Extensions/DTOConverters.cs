using Delivery.APIService.DTO;
using Delivery.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.APIService.Extensions
{
    public static class DTOConverters
    {
        public static List<DriverAPIServiceDTO> DriverRepositoryDTOsToAPIServiceDTOs(this List<DriverRepositoryDTO> driverRepositoryDTOs)
        {
            List<DriverAPIServiceDTO> drivers = new List<DriverAPIServiceDTO>();

            foreach (var driverRepositoryDTO in driverRepositoryDTOs)
            {
                DriverAPIServiceDTO driver = new DriverAPIServiceDTO()
                {
                    DriverID = driverRepositoryDTO.DriverID,
                    City = driverRepositoryDTO.City,
                    FirstName = driverRepositoryDTO.FirstName,
                    LastName = driverRepositoryDTO.LastName,
                    MobileNumber = driverRepositoryDTO.MobileNumber,
                };

                drivers.Add(driver);
            }
            return drivers;
        }
        public static List<CustomerAPIServiceDTO> CustomerRepositoryDTOsToCustomerAPIServiceDTOs(this List<CustomerRepositoryDTO> customerRepositoryDTOs)
        {
            List<CustomerAPIServiceDTO> customers = new List<CustomerAPIServiceDTO>();

            foreach (var customerRepositoryDTO in customerRepositoryDTOs)
            {
                CustomerAPIServiceDTO customer = new CustomerAPIServiceDTO()
                {
                    CustomerID = customerRepositoryDTO.CustomerID,
                    City = customerRepositoryDTO.City,
                    FirstName = customerRepositoryDTO.FirstName,
                    LastName = customerRepositoryDTO.LastName,
                    MobileNumber = customerRepositoryDTO.MobileNumber,
                };

                customers.Add(customer);
            }
            return customers;
        }
    }
}
