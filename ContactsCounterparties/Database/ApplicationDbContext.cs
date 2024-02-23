using ContactsCounterparties.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsCounterparties.Database;

public class ApplicationDbContext : DbContext
{
    public DbSet<Contact> Contacts { get; init; }
    public DbSet<Counterparty> Counterparties { get; init; }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Counterparty>()
            .HasMany(c => c.Contacts)
            .WithOne(e => e.Counterparty)
            .HasForeignKey(e => e.CounterpartyId)
            .HasPrincipalKey(e => e.Id);
    }
}