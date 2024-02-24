using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsCounterparties.Model;

[Table("Contacts")]
public class Contact : BaseModel
{
    public required string FirstName { get; init; }

    public required string LastName { get; init; }
    public required string Patronymic { get; init; }

    public required string Email { get; init; }

    public int? CounterpartyId { get; init; }
    public Counterparty? Counterparty { get; init; }
}