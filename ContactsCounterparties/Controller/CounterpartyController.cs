using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCounterparties.Controller;

[ApiController, Route("api/counterparty")]
public class CounterpartyController(ICounterpartySqlService contactSqlService) : ControllerBase
{
    [HttpPost]
    public ApiResponse<CreateCounterpartyResponseDto> Post(CreateCounterpartyRequestDto requestDto)
    {
        return new ApiResponse<CreateCounterpartyResponseDto>(contactSqlService.CreateCounterparty(requestDto));
    }
}