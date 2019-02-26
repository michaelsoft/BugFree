using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MichaelSoft.BugFree.WebApi.Utils
{
    /// <summary>
    /// Customized role authorization attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class CustomRolesAuthorizeFilterAttribute : Attribute, IAuthorizationFilter
    {
        /// <summary>
        /// Customized role authorization attribute constructor
        /// </summary>
        /// <param name="allowedRoles"></param>
        public CustomRolesAuthorizeFilterAttribute(params string[] allowedRoles)
        {
            AllowedRoles = allowedRoles;
        }

        /// <summary>
        /// User roles that are authorized
        /// </summary>
        public IEnumerable<string> AllowedRoles { get; }

        /// <summary>
        /// Anthenticate user role
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User != null)
            {
                bool found = false;
                if (this.AllowedRoles == null || !this.AllowedRoles.Any())
                {
                    found = true;
                }
                else
                {
                    found = this.AllowedRoles.Any(r => context.HttpContext.User.IsInRole(r));
                }
                if (!found)
                {
                    var result = new ObjectResult("Not authorized.");
                    result.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                    context.Result = result;
                }
            }
            else
            {
                var result = new ObjectResult("Not authorized.");
                result.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                context.Result = result;
            }
        }
    }
}
