using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppSettings _appSettings;

        public RoleController(IOptions<AppSettings> appSettings, RoleManager<IdentityRole> roleManager)
        {
            _appSettings = appSettings.Value;
            _roleManager = roleManager;

        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody]string roleName)
        {
            var role = new IdentityRole
            {
                 Name = roleName,
            };
            var result = await _roleManager.CreateAsync(role);
            return Ok(result);
        }

        [HttpPost("batch")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateRoles([FromBody]string[] roleNames)
        {
            var resultList = new List<IdentityResult>();
            foreach (var roleName in roleNames)
            {
                var role = new IdentityRole
                {
                    Name = roleName,
                };
                var result = await _roleManager.CreateAsync(role);
                resultList.Add(result);
            }

            return Ok(resultList);
        }


    }
}
