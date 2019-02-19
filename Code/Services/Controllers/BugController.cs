using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.ViewModels;
using Microsoft.AspNetCore.Authorization;
using MichaelSoft.BugFree.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using MichaelSoft.BugFree.WebApi.Exceptions;
using Microsoft.Extensions.Logging;

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class BugController : ControllerBase
    {
        private IBugService _bugService;
        private readonly ILogger _logger;

        public BugController(ILogger<BugController> logger, IBugService bugService)
        {
            _bugService = bugService;
            _logger = logger;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var bug = await _bugService.GetBugById(id);
            if (bug == null)
            {
                return NotFound();
            }
            var bugViewModel = AutoMapper.Mapper.Map<Bug, BugViewModel>(bug);
            if (bug.Attachments != null)
                bugViewModel.Attachments = AutoMapper.Mapper.Map<List<BugAttachment>, BugAttachmentViewModel[]>(bug.Attachments);
            return Ok(bug);
        }

        [HttpPost]
        public IActionResult Create(BugViewModel bugViewModel)
        {            
            var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
            if (bugViewModel.Attachments != null)
                bug.Attachments = AutoMapper.Mapper.Map<BugAttachmentViewModel[], List<BugAttachment>>(bugViewModel.Attachments);
            _bugService.CreateBug(bug);
            return Ok(bugViewModel.Id);
        }

        [HttpPut]
        public async Task<IActionResult> Update(BugViewModel bugViewModel)
        {
            try
            {
                var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
                if (bugViewModel.Attachments != null)
                    bug.Attachments = AutoMapper.Mapper.Map<BugAttachmentViewModel[], List<BugAttachment>>(bugViewModel.Attachments);
                await _bugService.UpdateBug(bug);
                return Ok();
            }
            catch(DataNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
