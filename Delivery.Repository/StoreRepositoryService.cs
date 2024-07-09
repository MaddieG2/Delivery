using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualBasic;
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

        public List<StoreDetailRepositoryDTO> GetStores(string city = "")
        {
            List<StoreDetailRepositoryDTO> stores = new List<StoreDetailRepositoryDTO>();
            String connectionString = _configuration.GetConnectionString("DeliveryDB");
            string query = "";
            if(city != "")
            {
                query = $"SELECT * FROM StoreDetails WHERE city = '{city}' AND ActiveStatus = '1'";
            }
            else
            {
                query = "SELECT * FROM StoreDetails WHERE ActiveStatus = '1'";
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var store = new StoreDetailRepositoryDTO
                        {
                            StoreId = (Guid)reader["StoreId"],
                            StoreName = (string)reader["StoreName"],
                            Street = (string)reader["Street"],
                            City = (string)reader["City"],
                            ZipCode = Int32.Parse((string)reader["ZipCode"]),
                            PhoneNumber = (string)reader["PhoneNumber"],
                            RegistrationDate = (DateTime)reader["RegistrationDate"],
                            ActiveStatus = (bool)reader["ActiveStatus"]
                        };
                        stores.Add(store);
                    }
                }
                return stores;
            }
        }
        public void CreateStore(StoreDetailRepositoryDTO storeDetails)
        {
            //This should write to the DB
            var connectionString = _configuration.GetConnectionString("DeliveryDB");

            using (SqlConnection connection = new SqlConnection(connectionString))
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
        public bool DeleteStore(Guid id)
        {
            var connectionString = _configuration.GetConnectionString("DeliveryDB");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
               
                SqlCommand command = new SqlCommand(
                      @"UPDATE StoreDetails SET ActiveStatus = '0' WHERE StoreID = @storeId");

                command.Parameters.Add(new SqlParameter("storeId", id));
                command.Connection = connection;
                command.ExecuteNonQuery();
            }

            return true;
        }
        public bool UpdateStore(StoreDetailRepositoryDTO storeDetail)
        {
            try
            {
                var connectionString = _configuration.GetConnectionString("DeliveryDB");

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand(
                      @"
                    UPDATE StoreDetails 
                    SET 
                        PhoneNumber  = @phoneNumber,
                        City = @city,
                        State = @state,
                        Street = @street,
                        StoreName = @storeName
                    WHERE StoreId = @storeId
                  ");

                    command.Parameters.Add(new SqlParameter("storeId", storeDetail.StoreId));
                    command.Parameters.Add(new SqlParameter("phoneNumber", storeDetail.PhoneNumber));
                    command.Parameters.Add(new SqlParameter("city", storeDetail.City));
                    command.Parameters.Add(new SqlParameter("street", storeDetail.Street));
                    command.Parameters.Add(new SqlParameter("state", storeDetail.State));
                    command.Parameters.Add(new SqlParameter("storeName", storeDetail.StoreName));

                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }            
            catch (Exception ex)
            {
                return false;
            }
           
            return true;
        }
    }
}
    
