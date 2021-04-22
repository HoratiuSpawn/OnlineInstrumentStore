using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineInstrumentStore.Models
{
    public class InstrumentModels
    {
        public Guid IDInstrument { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        public string InstrumentName { get; set; }
        public Guid IDManufacturer { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        public string InstrumentType { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }


    }
}