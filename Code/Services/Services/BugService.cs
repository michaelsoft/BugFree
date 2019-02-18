using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Services
{
    public interface IBugService
    {
        void CreateBug(Bug bug);

        Task UpdateBug(Bug bug);
    }

    public class BugService : IBugService
    {
        private readonly BugDbContext _dbContext;

        public BugService(IOptions<AppSettings> appSettings, BugDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBug(Bug bugData)
        {
            _dbContext.Bugs.Add(bugData);
            _dbContext.SaveChanges();
        }

        public async Task UpdateBug(Bug newBug)
        {
            var existingBug = await _dbContext.Bugs.Include(b => b.Attachments).FirstOrDefaultAsync(b => b.Id == newBug.Id);
            if (existingBug == null)
            {
                throw new DataNotFoundException($"Bug id { newBug.Id } is not found in db.");
            }

            // Insert or update attachments
            _dbContext.Entry(existingBug).CurrentValues.SetValues(newBug);
            foreach (var attachment in newBug.Attachments)
            {
                var existingAttachment = existingBug.Attachments
                    .Find(d => d.Id == attachment.Id);

                if (existingAttachment == null)
                {
                    existingBug.Attachments.Add(attachment);
                }
                else
                {
                    _dbContext.Entry(existingAttachment).CurrentValues.SetValues(attachment);
                }
            }


            //Handle deleting attachments
            foreach (var existingAttachment in existingBug.Attachments)
            {
                if (!newBug.Attachments.Exists( d => d.Id == existingAttachment.Id))
                {
                    _dbContext.BugAttachments.Remove(existingAttachment);
                }
            }

            

            _dbContext.SaveChanges();
        }

    }
}