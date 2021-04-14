using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class CustomerModels
    {
        public Guid IdCustomer { get; set; }
        public string CustomerName { get; set; }
        public String Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}