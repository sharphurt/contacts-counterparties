using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Model;

namespace ContactsCounterparties.Service;

public interface IContactSqlService
{
    public Contact GetContact(int id);
    public CreateContactResponseDto CreateContact(CreateContactRequestDto dto);
}