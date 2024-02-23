using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;

namespace ContactsCounterparties.Service;

public interface IContactSqlService
{
    public ContactInformationDto GetContact(int id);
    public CreateContactResponseDto CreateContact(ContactRequestDto dto);
    public void UpdateContact(int id, ContactRequestDto dto);
    public void DeleteContact(int id);
}