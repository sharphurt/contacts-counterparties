using ContactsCounterparties.Dto;
using ContactsCounterparties.Dto.Request;
using ContactsCounterparties.Dto.Response;
using ContactsCounterparties.Exception;
using ContactsCounterparties.Service;
using Microsoft.AspNetCore.Mvc;

namespace ContactsCounterparties.Controller;

[ApiController, Route("api/contact")]
public class ContactController(IContactSqlService sqlService) : ControllerBase
{
    [HttpGet]
    public ApiResponse<ContactInformationDto> Get([FromQuery] int id)
    {
        return new ApiResponse<ContactInformationDto>(sqlService.GetContact(id));
    }

    [HttpPost]
    public ApiResponse<CreateContactResponseDto> Post(ContactRequestDto requestDto)
    {
        if (!ModelState.IsValid)
            throw new ModelValidationException(nameof(ContactController), ModelState);
        
        return new ApiResponse<CreateContactResponseDto>(sqlService.CreateContact(requestDto));
    }

    [HttpPatch]
    public ApiResponse<SuccessfulOperationResponseDto> Update([FromQuery] int id, ContactRequestDto requestDto)
    {
        if (!ModelState.IsValid) 
            throw new ModelValidationException(nameof(ContactController), ModelState);
        
        sqlService.UpdateContact(id, requestDto);
        return new ApiResponse<SuccessfulOperationResponseDto>(new SuccessfulOperationResponseDto());
    }

    [HttpDelete]
    public ApiResponse<SuccessfulOperationResponseDto> Delete([FromQuery] int id)
    {
        sqlService.DeleteContact(id);
        return new ApiResponse<SuccessfulOperationResponseDto>(new SuccessfulOperationResponseDto());
    }
}