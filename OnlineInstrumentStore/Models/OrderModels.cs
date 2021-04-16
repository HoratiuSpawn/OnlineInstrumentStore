using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class OrderModels
    {
        public Guid IDOrder { get; set; }
        public Guid IDCustomer { get; set; }              
        
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        public String DeliveryAddress { get; set; }
        public Guid IDInstrument { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }


    }
}