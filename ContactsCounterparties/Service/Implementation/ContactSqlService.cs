using AutoMapper;
using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;

namespace ContactsCounterparties.Service.Implementation;

public class ContactSqlService(
    IContactRepository contactRepository,
    ICounterpartySqlService counterpartySqlService,
    IMapper mapper) : IContactSqlService
{
    public ContactInformationDto GetContact(int id)
    {
        return mapper.Map<ContactInformationDto>(contactRepository.GetById(id) ?? throw new EntityNotFoundException());
    }

    public CreateContactResponseDto CreateContact(ContactRequestDto dto)
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

    public void UpdateContact(int id, ContactRequestDto dto)
    {
        var model = GetContact(id);
        var updated = new Contact
        {
            Id = model.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Patronymic = dto.Patronymic,
            CounterpartyId = dto.CounterpartyId,
            UpdateTime = DateTime.Now
        };

        contactRepository.Update(updated);
    }

    public void DeleteContact(int id)
    {
        var currentInstance = GetContact(id);
        contactRepository.Delete(currentInstance.Id);
    }
}