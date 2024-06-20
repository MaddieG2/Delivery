using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Delivery.Repository
{
    public class StoreRepositoryService
    {
        private readonly IConfiguration _configuration;
        public StoreRepositoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void CreateStore(StoreDetailRepositoryDTO storeDetails)
        {
            //This should write to the DB
            var connectionString = _configuration.GetConnectionString("DeliveryDB");

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"INSERT INTO StoreDetails(StoreID, StoreName, Street, City, State, ZipCode, PhoneNumber, RegistrationDate, ActiveStatus) 
                      VALUES (@storeId, @storeName, @street, @city, @state, @zipCode, @phoneNumber, @registrationDate, @activeStatus)");

                command.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("storeId", storeDetails.StoreId),
                    new SqlParameter("storeName", storeDetails.StoreName),
                    new SqlParameter("street", storeDetails.Street),
                    new SqlParameter("city", storeDetails.City),
                    new SqlParameter("state", storeDetails.State),
                    new SqlParameter("zipCode", storeDetails.ZipCode),
                    new SqlParameter("phoneNumber", storeDetails.PhoneNumber),
                    new SqlParameter("registrationDate", storeDetails.RegistrationDate),
                    new SqlParameter("activeStatus", storeDetails.ActiveStatus),
                });
                command.Connection = connection; 
                command.ExecuteNonQuery();
            }
        }
    }
}
