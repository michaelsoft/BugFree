using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Collections.Generic;

namespace MichaelSoft.BugFree.WebApi.Entities
{
    public class BugDbContext : DbContext
    {
        public BugDbContext(DbContextOptions<BugDbContext> options)
                    : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var converter = new EnumToNumberConverter<BugState, int>();

            modelBuilder
                .Entity<Bug>()
                .Property(e => e.State)
                .HasConversion(converter);
        }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugAttachment> BugAttachments { get; set; }
    }

}
