using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class InstrumentModels
    {
        public Guid IDInstrument { get; set; }
        public string InstrumentName { get; set; }
        public Guid IDManufacturer { get; set; }
        public string InstrumentType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}