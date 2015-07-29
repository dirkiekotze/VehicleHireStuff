using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarsInventory.DataContext;
using CarsInventory.Entities;
using Microsoft.AspNet.Identity;

namespace CarsInventory.Filters
{

    public class LogAttribute : ActionFilterAttribute
    {
        public string Description;

        public IdentityDb Identity { get; set; }

        public InventoryDb Context { get; set; }
        public LogAttribute(string description)
        {
            Description = description;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var userId = filterContext.HttpContext.User.Identity.GetUserId();
            
            var user = Identity.Users.Find(userId);
            Context.LogAction.Add(new LogAction(
                user.UserName
                , filterContext.ActionDescriptor.ActionName
                , filterContext.ActionDescriptor.ControllerDescriptor.ControllerName
                , Description));
            Context.SaveChanges();
        }
    }
}