using Delivery.APIService.DTO;
using Delivery.APIService.Models;
using Delivery.Repository.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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
            public static List<StoreDetailAPIServiceDTO> StoreDetailRepositoryDTOsToStoreDetailAPIServiceDTO(this List<StoreDetailRepositoryDTO> storeDetailRepositoryDTOs)
            {
                List<StoreDetailAPIServiceDTO> stores = new List<StoreDetailAPIServiceDTO>();

                foreach (var storeDetailRepositoryDTO in storeDetailRepositoryDTOs)
                {
                StoreDetailAPIServiceDTO store = new StoreDetailAPIServiceDTO()
                    {
                    StoreId = storeDetailRepositoryDTO.StoreId,
                    StoreName = storeDetailRepositoryDTO.StoreName,
                    Street = storeDetailRepositoryDTO.Street,
                    City = storeDetailRepositoryDTO.City,
                    State = storeDetailRepositoryDTO.State,
                    ZipCode = storeDetailRepositoryDTO.ZipCode,
                    PhoneNumber = storeDetailRepositoryDTO.PhoneNumber,
                    RegistrationDate = storeDetailRepositoryDTO.RegistrationDate,
                    ActiveStatus = storeDetailRepositoryDTO.ActiveStatus,
                };

                    stores.Add(store);
                }
                return stores;
            }
        public static StoreDetailRepositoryDTO ToStoreDetailRepositoryDTO(this StoreDetail storeDetail) 
        {
            return new StoreDetailRepositoryDTO()
            {
                PhoneNumber = storeDetail.PhoneNumber,
                StoreId = storeDetail.StoreId,
                City = storeDetail.Address.City,
                State = storeDetail.Address.State,
                Street = storeDetail.Address.Street,
                ZipCode = storeDetail.Address.ZipCode,
                StoreName = storeDetail.StoreName,
            };
        }
    }
}
