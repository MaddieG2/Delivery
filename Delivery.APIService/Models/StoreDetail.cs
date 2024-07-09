

using System;

namespace Delivery.APIService.Models
{
    public class StoreDetail
    {
        public Guid StoreId { get; set; }
        public string StoreName { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
