using MichaelSoft.BugFree.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MichaelSoft.BugFree.WebApi.Services;
using System.Threading.Tasks;
using MichaelSoft.BugFree.WebApi.Utils;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System;
using Microsoft.Extensions.Options;
using MichaelSoft.BugFree.WebApi.ViewModels;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppSettings _appSettings;

        public AccountController(IOptions<AppSettings> appSettings, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody]User user)
        {
            var authResult = new AuthenticationResult();

            var result = await _signInManager.PasswordSignInAsync(user.Username, user.Password, false, false);
            if (result.Succeeded)
            {
                authResult.Result = AuthenticationResults.Succeeded;
            }
            else if (result.IsLockedOut)
            {
                authResult.ErrorMessage = "User is locked out.";
                authResult.Result = AuthenticationResults.LockedOut;
                return Ok(authResult);
            }
            else
            {
                authResult.ErrorMessage = "Invalid user name or password.";
                authResult.Result = AuthenticationResults.InvalidUserNameOrPassword;
                return Ok(authResult); 
            }

            var appUser = await _userManager.FindByNameAsync(user.Username);
            
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, appUser.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var userInfoViewModel = new UserInfoViewModel();
            userInfoViewModel.Token = tokenHandler.WriteToken(token);
            userInfoViewModel.UserName = user.Username;
            authResult.UserInfo = userInfoViewModel;

            return Ok(authResult);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody]User user)
        {
            var appUser = new AppUser()
            {
                 UserName = user.Username,
            };
            var result = await _userManager.CreateAsync(appUser, user.Password);
            return Ok(result);
        }

    }
}
