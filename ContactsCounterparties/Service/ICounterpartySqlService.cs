using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Model;

namespace ContactsCounterparties.Service;

public interface ICounterpartySqlService
{
    public CounterpartyInformationDto GetCounterparty(int id);

    public CreateCounterpartyResponseDto CreateCounterparty(CreateCounterpartyRequestDto dto);
    IEnumerable<CounterpartyInformationDto> GetAllCounterparties();
}