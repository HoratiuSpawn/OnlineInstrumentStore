using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class OrderModels
    {
        public Guid IDOrder { get; set; }
        public Guid IDCustomer { get; set; }
        public DateTime Date { get; set; }
        public String DeliveryAddress { get; set; }
        public Guid IDInstrument { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


    }
}