namespace ContactsCounterparties.Dto.Request;

public class ContactRequestDto
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Patronymic { get; init; }
    public int? CounterpartyId { get; init; }
}