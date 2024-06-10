using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Delivery.Repository
{
    public class RepositoryService
    {

        private readonly IConfiguration _configuration;

        public RepositoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<DriverRepositoryDTO> GetDrivers()
        {
            List<DriverRepositoryDTO> drivers = new List<DriverRepositoryDTO>();

            string connectionString = _configuration.GetConnectionString("DeliveryDB");
            string query = "SELECT * FROM Driver";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var driver = new DriverRepositoryDTO
                        {
                            DriverID = (Int32)reader["DriverID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            City = (string)reader["City"],
                            MobileNumber = (string)reader["MobileNumber"],
                        };
                        drivers.Add(driver);
                    }
                }
            }
            return drivers;
        }
    }
}
