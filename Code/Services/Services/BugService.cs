using MichaelSoft.BugFree.WebApi.Data;
using MichaelSoft.BugFree.WebApi.Entities;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace MichaelSoft.BugFree.WebApi.Services
{
    public interface IBugService
    {
        void CreateBug(Bug bug);
    }

    public class BugService : IBugService
    {
        private readonly BugDbContext _dbContext;

        public BugService(IOptions<AppSettings> appSettings, BugDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateBug(Bug bug)
        {
            var bugData = AutoMapper.Mapper.Map<Bug, BugData>(bug);
            _dbContext.Bugs.Add(bugData);
            _dbContext.SaveChangesAsync();
        }

    }
}