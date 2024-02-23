using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCounterparties.Controller;

[ApiController, Route("api/counterparty")]
public class CounterpartyController(ICounterpartySqlService sqlService) : ControllerBase
{
    [HttpGet]
    public ApiResponse<CounterpartyInformationDto> Get([FromQuery] int id)
    {
        return new ApiResponse<CounterpartyInformationDto>(sqlService.GetCounterparty(id));
    }

    [HttpGet]
    [Route("all")]
    public ApiResponse<IEnumerable<CounterpartyInformationDto>> GetAll()
    {
        return new ApiResponse<IEnumerable<CounterpartyInformationDto>>(sqlService.GetAllCounterparties());
    }

    [HttpPost]
    public ApiResponse<CreateCounterpartyResponseDto> Post(CounterpartyRequestDto requestDto)
    {
        return new ApiResponse<CreateCounterpartyResponseDto>(sqlService.CreateCounterparty(requestDto));
    }
}