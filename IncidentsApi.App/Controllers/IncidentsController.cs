using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Abstractions;
using IncidentsApi.Data.Models;
using System.Net.Mime;

namespace IncidentsApi.App.Controllers;


[ApiController]
[Route("[controller]")]
public class IncidentsController : ControllerBase
{
    private readonly IIncidentsRepo _incidentsRepo;
    public record CreateIncidentRequestBody(
        string AccountName,
        string ContactEmail,
        string ContactFirstName,
        string ContactLastName,
        string IncidentDescription
    );


    public IncidentsController(IIncidentsRepo incidentsRepo)
    {
        _incidentsRepo = incidentsRepo;
    }


    [HttpPost("Create")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async ValueTask<IActionResult> Create(
        [FromServices] IAccountsRepo accountsRepo,
        [FromServices] IContactsRepo contactsRepo,
        CreateIncidentRequestBody body
    )
    {

        Account account = new() { Name = body.AccountName };
        Contact contact = new() { Email = body.ContactEmail, FirstName = body.ContactFirstName, LastName = body.ContactLastName };
        Incident incident = new() { Description = body.IncidentDescription };

        if (!TryValidateModel(account) || !TryValidateModel(contact) || !TryValidateModel(incident))
            return BadRequest(ModelState);


        if (!await accountsRepo.ExistsAsync(account))
            return NotFound();

        if (await contactsRepo.ExistsAsync(contact))
        {
            if (await contactsRepo.IsLinkedAsync(contact))
                return Conflict();
            else
                contactsRepo.Update(contact);
        }

        account.Contacts.Add(contact);
        account.Incidents.Add(incident);
        accountsRepo.Update(account);
        await _incidentsRepo.SaveChangesAsync();

        return Ok();
    }
}
