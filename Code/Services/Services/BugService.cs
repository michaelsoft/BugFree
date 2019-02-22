using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace MichaelSoft.BugFree.WebApi.Services
{
    public interface IBugService
    {
        Task<int> CreateBug(Bug bug);

        Task UpdateBug(Bug bug);

        Task DeleteBug(int id);

        Task<Bug> GetBugById(int id);

        Task<dynamic> QueryBugs(BugPredicate bugPred);
    }

    public class BugService : IBugService
    {
        private readonly BugDbContext _dbContext;

        public BugService(IOptions<AppSettings> appSettings, BugDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateBug(Bug bug)
        {
            _dbContext.Bugs.Add(bug);
            await _dbContext.SaveChangesAsync();
            return bug.Id;
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

        public async Task DeleteBug(int id)
        {
            var bug = await _dbContext.Bugs.Include(b => b.Attachments).FirstOrDefaultAsync();
            if (bug == null)
                throw new DataNotFoundException($"Bug {id} does not exist in db.");

            _dbContext.Bugs.Remove(bug);
            await _dbContext.SaveChangesAsync();
        } 

        public async Task<Bug> GetBugById(int id)
        {
            return await _dbContext.Bugs.Include(b => b.Attachments).FirstOrDefaultAsync<Bug>(b => b.Id == id);
        }

        public async Task<dynamic> QueryBugs(BugPredicate bugPred)
        {
            var query = from b in _dbContext.Bugs
                        select new { Id = b.Id, Tittle = b.Tittle, State = b.State };


            if (bugPred.Id.HasValue)
                query = query.Where(d => d.Id == bugPred.Id.Value);

            if (!string.IsNullOrWhiteSpace(bugPred.Tittle))
                query = query.Where(d => d.Tittle.Contains(bugPred.Tittle));

            //if (bugPred.StateId != null && bugPred.StateId.Length > 0)
            //query.Where(d => d.State == bugPred.Id.Value);

            return await query.ToListAsync();
        }
    }
}