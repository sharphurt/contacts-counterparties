using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Model;
using ContactsCounterparties.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCounterparties.Controller;

[ApiController, Route("api/contact")]
public class ContactController(IContactSqlService contactSqlService) : ControllerBase
{
    [HttpGet]
    [Route("{id:int}")]
    public ApiResponse<Contact> Get(int id)
    {
        return new ApiResponse<Contact>(contactSqlService.GetContact(id));
    }

    [HttpPost]
    public ApiResponse<CreateContactResponseDto> Post(CreateContactRequestDto requestDto)
    {
        return new ApiResponse<CreateContactResponseDto>(contactSqlService.CreateContact(requestDto));
    }
}