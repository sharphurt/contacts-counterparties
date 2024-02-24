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
    IMapper mapper) : IContactSqlService
{
    public ContactInformationDto GetContact(int id)
    {
        var contact = contactRepository.GetById(id) ?? throw new EntityNotFoundException(nameof(ContactSqlService), id.ToString());
        return mapper.Map<ContactInformationDto>(contact);
    }

    public CreateContactResponseDto CreateContact(ContactRequestDto dto)
    {
        var model = new Contact
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Patronymic = dto.Patronymic,
            CounterpartyId = dto.CounterpartyId,
            Email = dto.Email,
            UpdateTime = DateTime.Now,
            CreationTime = DateTime.Now
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
            Email = dto.Email,
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