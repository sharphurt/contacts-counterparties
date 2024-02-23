using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;

namespace ContactsCounterparties.Service;

public interface ICounterpartySqlService
{
    public CounterpartyInformationDto GetCounterparty(int id);

    public CreateCounterpartyResponseDto CreateCounterparty(CounterpartyRequestDto dto);
    IEnumerable<CounterpartyInformationDto> GetAllCounterparties();
}