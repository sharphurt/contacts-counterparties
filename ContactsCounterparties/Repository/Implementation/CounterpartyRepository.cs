using ContactsCounterparties.Database;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsCounterparties.Repository.Implementation;

public class CounterpartyRepository(ApplicationDbContext context) : ICounterpartyRepository
{
    private bool _disposed;

    public int Create(Counterparty model)
    {
        context.Counterparties.Add(model);
        context.SaveChanges();

        return model.Id;
    }

    public IEnumerable<Counterparty> GetAll()
    {
        return context.Counterparties.ToList();
    }

    public Counterparty? GetById(int id)
    {
        return context.Counterparties.Find(id);
    }
    
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}