using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Inventario.Models;

namespace inventario.Filters
{

    public class RoleFilter : AuthorizeAttribute
    {
        private readonly string[] _requiredRole;

        public RoleFilter(params string[] requiredRole)
        {
            _requiredRole = requiredRole;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var isAuthorized = base.AuthorizeCore(httpContext);
            if (!isAuthorized)
            {
                return false;
            }

            var user = httpContext.User;

            if (user != null && user.Identity.IsAuthenticated)
            {
                InventarioEntities5 db = new InventarioEntities5();
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var userId = user.Identity.GetUserId();
                AspNetUsers aspNetUsers = db.AspNetUsers.Find(userId);
                var userRole = aspNetUsers.RoleId;
                if (_requiredRole.Any(requiredRole => userRole.Contains(requiredRole)))
                {
                    return true;
                }
            }

            return false;
        }
    }
}