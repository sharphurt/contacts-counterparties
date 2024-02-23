using System.Collections;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ContactsCounterparties.Model;

[Table("Counterparties")]
public record Counterparty : BaseModel
{
    public required string Name { get; init; }
    [JsonIgnore] public IEnumerable<Contact>? Contacts { get; init; }
}