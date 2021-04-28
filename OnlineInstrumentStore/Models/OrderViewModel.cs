using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class OrderViewModel
    {
        public Guid IDOrder { get; set; }
        public DateTime Data { get; set; }
        public String DeliveryAddress { get; set; }
        public string IDInstrumentName { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
    }
}