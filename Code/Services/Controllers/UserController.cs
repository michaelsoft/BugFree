using MichaelSoft.BugFree.WebApi.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly AppSettings _appSettings;

        public UserController(IOptions<AppSettings> appSettings, UserManager<AppUser> userManager)
        {
            _appSettings = appSettings.Value;
            _userManager = userManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> CreateUser([FromBody]AppUserViewModel appUserViewModel)
        {
            var appUser = AutoMapper.Mapper.Map<AppUserViewModel, AppUser>(appUserViewModel);

            var result = await _userManager.CreateAsync(appUser, appUser.Password);
            if (result.Succeeded && appUserViewModel.Roles != null && appUserViewModel.Roles.Count > 0)
            {
                var roleResult = await _userManager.AddToRolesAsync(appUser, appUserViewModel.Roles);
                if (!roleResult.Succeeded)
                {//If role creation fails, rollback the user creation also. Here we don't want use TransactionScope as it depends on MSDTC.
                    await _userManager.DeleteAsync(appUser);
                }
                    
                return Ok(roleResult);
            }

            return Ok(result);
        }

        [HttpPut]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser([FromBody]AppUserViewModel appUserViewModel)
        {
            var existingUser = await _userManager.FindByNameAsync(appUserViewModel.UserName);
            if (existingUser == null)
            {
                return BadRequest($"User {appUserViewModel.UserName} not found.");
            }

            var appUser = AutoMapper.Mapper.Map<AppUserViewModel, AppUser>(appUserViewModel, existingUser);
            //appUser.Id = existingUser.Id;
            //var appUser = existingUser;

            var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded)
            {
                var existingRoles = await _userManager.GetRolesAsync(existingUser);
                await _userManager.RemoveFromRolesAsync(existingUser, existingRoles);
                if (appUserViewModel.Roles != null && appUserViewModel.Roles.Count > 0)
                {
                    var roleResult = await _userManager.AddToRolesAsync(existingUser, appUserViewModel.Roles);
                    return Ok(roleResult);
                }
            }

            return Ok(result);
        }

        [HttpGet("{userName}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUser([FromRoute]string userName)
        {
            AppUserViewModel appUserViewModel = null;
            var existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser != null)
            {
                appUserViewModel = AutoMapper.Mapper.Map<AppUser, AppUserViewModel>(existingUser);

                var existingRoles = await _userManager.GetRolesAsync(existingUser);
                if (existingRoles != null && existingRoles.Count > 0)
                {
                    appUserViewModel.Roles = new List<string>();
                    appUserViewModel.Roles.AddRange(existingRoles);
                }
            }

            return Ok(appUserViewModel);
        }


    }
}
