using Microsoft.AspNetCore.Http;
using PandaPe.Data.Models.Base;
using PandaPe.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Emit;

namespace PandaPe.Data.DataAccess
{
    public class PandaPeDbContext : DbContext
    {
        DbSet<Candidate> Candidates { get; set; }

        public PandaPeDbContext()
        {

        }
        public PandaPeDbContext(DbContextOptions<PandaPeDbContext> options) : base(options)
        {

        }
        public override async Task<int> SaveChangesAsync(CancellationToken cancellation)
        {
            var selectedEntityListAdded = ChangeTracker.Entries()
                        .Where(x => x.Entity is EntityBase<int> &&
                        x.State == EntityState.Added);

            var selectedEntityListUpdate = ChangeTracker.Entries()
                        .Where(x => x.Entity is EntityBase<int> &&
                        x.State == EntityState.Modified);

            foreach (var entity in selectedEntityListAdded)
            {
                ((EntityBase<int>)entity.Entity).ModifyDate = DateTime.UtcNow;
            }

            foreach (var entity in selectedEntityListUpdate)
            {
                ((EntityBase<int>)entity.Entity).ModifyDate = DateTime.UtcNow;
            }

            return await base.SaveChangesAsync(cancellation).ConfigureAwait(false);
        }
    }
}