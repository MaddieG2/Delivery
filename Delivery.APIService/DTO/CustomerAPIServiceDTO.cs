using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.APIService.DTO
{
    public class CustomerAPIServiceDTO
    {
            public int CustomerID { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string City { get; set; }
            public string MobileNumber { get; set; }
    }
}

