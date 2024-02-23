using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsCounterparties.Model;

[Table("Counterparties")]
public class Counterparty : BaseModel
{
    public required string Name { get; init; }
    public IEnumerable<Contact>? Contacts { get; init; }

    public IEnumerable<int>? GetContactIds()
    {
        return Contacts?.Select(c => c.Id);
    }
}