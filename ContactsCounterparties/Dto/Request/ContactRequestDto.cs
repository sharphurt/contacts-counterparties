namespace ContactsCounterparties.Dto.Request;

public record ContactRequestDto(string FirstName, string LastName, string Patronymic, int? CounterpartyId);