using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using CarsInventory.Entities;

namespace CarsInventory.Models
{
    public class CreateInvoice
    {
        
        
        public int VehicleId { get; set; }
        [Required]
        public string Hirer { get; set; }
        public string EMailAddress { get; set; }
        public string Telephone { get; set; }
        [Required]
        public Destination Destination { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:dd/mm/yy}")]
        public DateTime StartDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/mm/yy}")]
        public DateTime EndDate { get; set; }
        public string Comment { get; set; }
        [Required]
        public double Price { get; set; }

        public int NumberOfDays { get; set; }

        [ForeignKey("VehicleId")]
        public Vehicle Vehicle { get; set; }
    }
}