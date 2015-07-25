using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarsInventory.Entities
{
    public class Vehicle
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Description { get; set; }
        [Required]
        public Seat NumberOfSeats { get; set; }
        [Required]
        public string RegistrationNo { get; set; }
        [Required]
        public int Kms { get; set; }
        public FuelType FuelType { get; set; }
        

        
    }
}