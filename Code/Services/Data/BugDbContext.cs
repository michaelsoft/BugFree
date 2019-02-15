using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace MichaelSoft.BugFree.WebApi.Data
{
    public class BugDbContext : DbContext
    {
        public BugDbContext(DbContextOptions<BugDbContext> options)
                    : base(options)
        { }

        public DbSet<BugData> Bugs { get; set; }
    }

}
