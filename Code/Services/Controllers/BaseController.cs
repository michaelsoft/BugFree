using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MichaelSoft.BugFree.WebApi.Utils;
using MichaelSoft.BugFree.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MichaelSoft.BugFree.WebApi.Exceptions;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        private readonly ILogger _logger;

        public BaseController(ILogger<BugController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// ToDo: To get this once for a request.
        /// </summary>
        protected AppUser CurrentUser
        {
            get
            {
                if (base.User != null)
                {
                    var appUser = new AppUser();

                    appUser.Id = base.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                    appUser.UserName = base.User.FindFirst(ClaimTypes.Name)?.Value;

                    return appUser;
                }

                return null;
            }
        }

    }
}
