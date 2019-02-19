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
            var bugStateConverter = new EnumToNumberConverter<BugState, int>();

            modelBuilder
                .Entity<Bug>()
                .HasMany(b => b.Attachments)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
               .Entity<Bug>()
               .Property(e => e.State)
               .HasConversion(bugStateConverter);
        }

        public DbSet<Bug> Bugs { get; set; }

        public DbSet<BugAttachment> BugAttachments { get; set; }
    }

}
