using ContactsCounterparties.Database;
using ContactsCounterparties.Model;
using Microsoft.EntityFrameworkCore;

namespace ContactsCounterparties.Repository.Implementation;

public class ContactRepository(ApplicationDbContext context) : IContactRepository
{
    private bool _disposed;

    public int Create(Contact model)
    {
        context.Contacts.Add(model);
        context.SaveChanges();

        return model.Id;
    }

    public IEnumerable<Contact> GetAll()
    {
        return context.Contacts.ToList();
    }

    public Contact? GetById(int id)
    {
        return context.Contacts.Include(c => c.Counterparty).FirstOrDefault(c => c.Id == id);
    }

    public void Update(Contact model)
    {
        context.Entry(model).State = EntityState.Modified;
        context.SaveChanges();
        context.Entry(model).State = EntityState.Detached;
    }

    public void Delete(int id)
    {
        var entity = context.Contacts.Find(id);
        context.Contacts.Remove(entity);
        context.SaveChanges();
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