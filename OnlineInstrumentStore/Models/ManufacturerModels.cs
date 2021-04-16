using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineInstrumentStore.Models
{
    public class ManufacturerModels
    {
        public Guid IDManufacturer { get; set; }

        [Required(ErrorMessage = "Mandatory field")]
        [StringLength(250, ErrorMessage = "String too long (max. 250 chars)")]
        public string ManufacturerName { get; set; }
    }
}