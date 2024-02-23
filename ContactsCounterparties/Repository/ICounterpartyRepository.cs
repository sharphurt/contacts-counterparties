using ContactsCounterparties.Model;

namespace ContactsCounterparties.Repository;

public interface ICounterpartyRepository : IDisposable
{
    public int Create(Counterparty model);
    public IEnumerable<Counterparty> GetAll();
    public Counterparty? GetById(int id);
}