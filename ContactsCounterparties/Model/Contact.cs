using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace ContactsCounterparties.Model;

[Table("Contacts")]
public record Contact : BaseModel
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Patronymic { get; init; }

    [JsonIgnore] public int? CounterpartyId { get; init; }
    public Counterparty? Counterparty { get; init; }
}