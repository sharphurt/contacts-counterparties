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
    public ApiResponse<Contact> Get([FromQuery] int id)
    {
        return new ApiResponse<Contact>(contactSqlService.GetContact(id));
    }

    [HttpPost]
    public ApiResponse<CreateContactResponseDto> Post(ContactRequestDto requestDto)
    {
        return new ApiResponse<CreateContactResponseDto>(contactSqlService.CreateContact(requestDto));
    }

    [HttpPatch]
    public ApiResponse<UpdateContactResponseDto> Update([FromQuery] int id, ContactRequestDto requestDto)
    {
        contactSqlService.UpdateContact(id, requestDto);
        return new ApiResponse<UpdateContactResponseDto>(new UpdateContactResponseDto());
    }
}