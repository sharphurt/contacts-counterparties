using ContactsCounterparties.Model;

namespace ContactsCounterparties.Repository;

public interface IContactRepository : IDisposable
{
    public int Create(Contact model);
    public IEnumerable<Contact> GetAll();
    public Contact? GetById(int id);
    public void Update(Contact model);
    public void Delete(int id);
}