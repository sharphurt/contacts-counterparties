namespace ContactsCounterparties.Dto.Request;

public record CreateContactRequestDto(string FirstName, string LastName, string Patronymic, int? CounterpartyId);