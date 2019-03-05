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

namespace MichaelSoft.BugFree.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BugController : BaseController
    {
        private IBugService _bugService;

        public BugController(ILogger<BugController> logger, IBugService bugService): base(logger)
        {
            _bugService = bugService;
        }

        [HttpPost]
        [Authorize(Roles = "Bug-Create")]
        public async Task<IActionResult> Create([FromBody]BugViewModel bugViewModel)
        {            
            if (!this.ModelState.IsValid)
            {
                return BadRequest();
            }

            var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
            if (bugViewModel.Attachments != null)
                bug.Attachments = AutoMapper.Mapper.Map<List<BugAttachmentViewModel>, List<BugAttachment>>(bugViewModel.Attachments);
            var newId = await _bugService.CreateBug(bug, base.CurrentUser);
            return Ok(newId);
        }

        [HttpPut]
        [Authorize(Roles = "Bug-Update")]
        public async Task<IActionResult> Update(BugViewModel bugViewModel)
        {
            try
            {
                var bug = AutoMapper.Mapper.Map<BugViewModel, Bug>(bugViewModel);
                if (bugViewModel.Attachments != null)
                    bug.Attachments = AutoMapper.Mapper.Map<List<BugAttachmentViewModel>, List<BugAttachment>>(bugViewModel.Attachments);
                await _bugService.UpdateBug(bug, base.CurrentUser);
                return Ok();
            }
            catch(BugFreeException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Bug-Delete")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                await _bugService.DeleteBug(id);
            }
            catch(BugFreeException ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Bug-View")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            var bug = await _bugService.GetBugById(id);
            if (bug == null)
            {
                return NotFound();
            }
            var bugViewModel = AutoMapper.Mapper.Map<Bug, BugViewModel>(bug);
            if (bug.Attachments != null)
                bugViewModel.Attachments = AutoMapper.Mapper.Map<List<BugAttachment>, List<BugAttachmentViewModel>>(bug.Attachments);
            return Ok(bug);
        }

        [HttpGet("q")]
        [Authorize(Roles = "Bug-View")]
        public async Task<IActionResult> Query([FromQuery]int? id, [FromQuery]string tittle)
        {
            var bugPred = new BugPredicate()
            {
                Id = id,
                Tittle = tittle
            };

            var result = await _bugService.QueryBugs(bugPred);
            return Ok(result);
        }

    }
}
