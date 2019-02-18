using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MichaelSoft.BugFree.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class BugController : ControllerBase
    {
        private IBugService _bugService;

        public BugController(IBugService bugService)
        {
            _bugService = bugService;
        }

        [HttpPost]
        public IActionResult Create(BugViewModel bugViewModel)
        {            
            var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
            if (bugViewModel.Attachments != null)
                bug.Attachments = AutoMapper.Mapper.Map<BugAttachmentViewModel[], List<BugAttachment>>(bugViewModel.Attachments);
            _bugService.CreateBug(bug);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(BugViewModel bugViewModel)
        {
            var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
            if (bugViewModel.Attachments != null)
                bug.Attachments = AutoMapper.Mapper.Map<BugAttachmentViewModel[], List<BugAttachment>>(bugViewModel.Attachments);
            await _bugService.UpdateBug(bug);
            return Ok();
        }

    }
}
