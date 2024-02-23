namespace ContactsCounterparties.Dto.Response;

public class CounterpartyInformationDto
{
    public required int Id { get; init; }
    public string Name { get; init; }
    public IEnumerable<int> ContactIds { get; init; }
}