using Delivery.Repository.DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Delivery.Repository
{
   public class CustomerRepositoryService
    {
        private readonly IConfiguration _configuration;

        public CustomerRepositoryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<CustomerRepositoryDTO> GetCustomers()
        {
            List<CustomerRepositoryDTO> customers = new List<CustomerRepositoryDTO>();

            string connectionString = _configuration.GetConnectionString("DeliveryDB");
            string query = "SELECT * FROM Customer";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        var customer = new CustomerRepositoryDTO
                        {
                            CustomerID = (Int32)reader["CustomerID"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            City = (string)reader["City"],
                            MobileNumber = (string)reader["MobileNumber"],
                        };
                        customers.Add(customer);
                    }
                }
            }
            return customers;
        }
    }
}
