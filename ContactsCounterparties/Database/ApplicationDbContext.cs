using ContactsCounterparties.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsCounterparties.Database;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Contact> Contacts { get; init; }
    public DbSet<Counterparty> Counterparties { get; init; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Counterparty>()
            .HasMany(c => c.Contacts)
            .WithOne(e => e.Counterparty)
            .HasForeignKey(e => e.CounterpartyId)
            .HasPrincipalKey(e => e.Id);
    }
}