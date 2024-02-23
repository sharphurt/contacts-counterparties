using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;

namespace ContactsCounterparties.Service.Implementation;

public class ContactSqlService(
    IContactRepository contactRepository,
    ICounterpartySqlService counterpartySqlService) : IContactSqlService
{
    public Contact GetContact(int id)
    {
        return contactRepository.GetById(id) ?? throw new EntityNotFoundException();
    }

    public CreateContactResponseDto CreateContact(CreateContactRequestDto dto)
    {
        var model = new Contact
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Patronymic = dto.Patronymic,
            CounterpartyId = dto.CounterpartyId
        };
        
        return new CreateContactResponseDto(contactRepository.Create(model));
    }

    /*public void UpdateContact(int id, ContactDto dto)
    {
        var counterparty = GetCounterpartyOrNull(dto.CounterpartyId);
        var model = GetContact(id);
        var updated = new Contact(model.Id, dto.FirstName, dto.LastName, dto.Patronymic, counterparty);
        contactRepository.Update(updated);
    }*/

    public void DeleteContact(int id)
    {
        var currentInstance = GetContact(id);
        contactRepository.Delete(currentInstance.Id);
    }

    private Counterparty? GetCounterpartyOrNull(int? counterpartyId)
    {
        return counterpartyId.HasValue ? counterpartySqlService.GetById(counterpartyId.Value) : null;
    }
}