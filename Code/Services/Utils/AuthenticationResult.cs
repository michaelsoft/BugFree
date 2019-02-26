using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Utils
{
    public class AuthenticationResult
    {
        public AuthenticationResults Result { get; set; } = AuthenticationResults.Default;

        public string ErrorMessage { get; set; } = string.Empty;

        public AppUserViewModel User { get; set; }

    }

    public enum AuthenticationResults: int
    {
        Succeeded = 1,
        InvalidUserNameOrPassword,
        LockedOut,
        PasswordExpired,
        Default = InvalidUserNameOrPassword,
    }
}
