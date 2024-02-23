using ContactsCounterparties.Dto.Response;

namespace ContactsCounterparties.Dto;

public record ContactInformationDto
{
    public required int Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Patronymic { get; init; }
    public CounterpartyInformationDto? Counterparty { get; init; }
}