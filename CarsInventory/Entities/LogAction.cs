using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CarsInventory.Models;

namespace CarsInventory.Entities
{
    public class LogAction
    {
        public LogAction(string performedBy, string action, string controller, string description)
        {
            PerformedBy = performedBy;
            Action = action;
            Controller = controller;
            Description = description;
            PerformedAt = DateTime.Now;
        }

        [Key]
        public int LogActionId { get; set; }

        [DataType(DataType.Date)]
        public DateTime PerformedAt { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string PerformedBy { get; set; }

        public string Description { get; set; }
    }
}