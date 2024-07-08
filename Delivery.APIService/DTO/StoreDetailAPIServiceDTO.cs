using System;
using System.Collections.Generic;
using System.Text;

namespace Delivery.APIService.DTO
{
    public class StoreDetailAPIServiceDTO
    {
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int ZipCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool ActiveStatus { get; set; }
    }
}
