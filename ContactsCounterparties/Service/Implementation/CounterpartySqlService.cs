using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;

namespace ContactsCounterparties.Service.Implementation;

public class CounterpartySqlService(ICounterpartyRepository counterpartyRepository) : ICounterpartySqlService
{
    public Counterparty GetById(int id)
    {
        return counterpartyRepository.GetById(id) ?? throw new EntityNotFoundException();
    }

    public CreateCounterpartyResponseDto CreateCounterparty(CreateCounterpartyRequestDto dto)
    {
        var model = new Counterparty
        {
            Name = dto.Name
        };

        return new CreateCounterpartyResponseDto(counterpartyRepository.Create(model));
    }
}