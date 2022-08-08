using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Abstractions;
using IncidentsApi.Data.Models;
using System.Net.Mime;

namespace IncidentsApi.App.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{
    private readonly IContactsRepo _contactsRepo;
    public record CreateContactRequestBody(
        string Email,
        string FirstName,
        string LastName
    );


    public ContactsController(IContactsRepo contactsRepo)
    {
        _contactsRepo = contactsRepo;
    }

    [HttpPost("Create")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async ValueTask<IActionResult> Create(CreateContactRequestBody body)
    {
        Contact contact = new Contact { Email = body.Email, FirstName = body.FirstName, LastName = body.LastName };

        ModelState.ClearValidationState(nameof(Contact));
        if (!TryValidateModel(contact))
            return BadRequest(ModelState);

        if (await _contactsRepo.ExistsAsync(contact))
            return Conflict();

        await _contactsRepo.AddAsync(contact);
        await _contactsRepo.SaveChangesAsync();
        return Ok();
    }
}
