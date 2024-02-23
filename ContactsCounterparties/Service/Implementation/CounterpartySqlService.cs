using AutoMapper;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Model;
using ContactsCounterparties.Repository;

namespace ContactsCounterparties.Service.Implementation;

public class CounterpartySqlService(
    ICounterpartyRepository counterpartyRepository,
    IMapper mapper) : ICounterpartySqlService
{
    public CounterpartyInformationDto GetCounterparty(int id)
    {
        var counterparty = counterpartyRepository.GetById(id) ?? throw new EntityNotFoundException();
        return mapper.Map<Counterparty, CounterpartyInformationDto>(counterparty);
    }

    public CreateCounterpartyResponseDto CreateCounterparty(CreateCounterpartyRequestDto dto)
    {
        var model = new Counterparty
        {
            Name = dto.Name
        };

        return new CreateCounterpartyResponseDto(counterpartyRepository.Create(model));
    }

    public IEnumerable<CounterpartyInformationDto> GetAllCounterparties()
    {
        var counterparties = counterpartyRepository.GetAll();
        return mapper.Map<IEnumerable<Counterparty>, IEnumerable<CounterpartyInformationDto>>(counterparties);
    }
}