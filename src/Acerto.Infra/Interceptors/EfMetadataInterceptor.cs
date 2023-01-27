using Acerto.Business.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Acerto.Infra.Interceptors
{
    public class EfMetadataInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            var changeDate = DateTime.UtcNow;

            var entries = eventData.Context!.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (var entry in entries)
            {
                var entity = entry.Entity as Entity;

                if (entry.State == EntityState.Added)
                    entity!.SetCreationDate(changeDate);
                else
                    entry.Property(nameof(Entity.CreatedAt)).IsModified = false;

                entity!.SetUpdateDate(changeDate);
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}