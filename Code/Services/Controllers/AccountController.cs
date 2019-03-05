using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.Utils;
using MichaelSoft.BugFree.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

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

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody]LoginInfo loginInfo)
        {
            var authResult = new AuthenticationResult();

            var result = await _signInManager.PasswordSignInAsync(loginInfo.UserName, loginInfo.Password, loginInfo.RememberMe, true);
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

            var appUser = await _userManager.FindByNameAsync(loginInfo.UserName);

            var roles = await _userManager.GetRolesAsync(appUser);
            var roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r) );
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, appUser.Id));
            claims.Add(new Claim(ClaimTypes.Name, appUser.UserName));
            claims.AddRange(roleClaims.ToArray<Claim>());

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(1),
                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);

            var appUserViewModel =  AutoMapper.Mapper.Map<AppUser, AppUserViewModel>(appUser);
            appUserViewModel.Token = tokenHandler.WriteToken(token);
            authResult.User = appUserViewModel;

            return Ok(authResult);
        }



    }
}
