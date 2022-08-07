using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Interfaces;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Host.Controllers;


[ApiController]
[Route("[controller]")]
public class CreateController : ControllerBase
{
    private readonly IIncidentsRepo _incidentsRepo;
    public CreateController(IIncidentsRepo incidentsRepo)
    {
        _incidentsRepo = incidentsRepo;
    }


    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async ValueTask<IActionResult> Create(
        [FromServices] IAccountsRepo accountsRepo,
        [FromServices] IContactsRepo contactsRepo,
        [Bind("Name", Prefix = "Account")] Account accountFromRequest,
        [Bind("FirstName", "LastName", "Email", Prefix = "Contact")] Contact contactFromRequest,
        [Bind("Description", Prefix = "Incident")] Incident incidentFromRequest
    )
    {
        Account? accountInRepo = await accountsRepo.FindAsync(accountFromRequest.Name);
        if (accountInRepo is null)
            return NotFound();

        Contact? contactInRepo = await contactsRepo.FindAsync(contactFromRequest.Email);


        accountInRepo.Contacts.Add(contactFromRequest);
        incidentFromRequest.AccountNavigation = accountInRepo;
        await _incidentsRepo.AddAsync(incidentFromRequest);
        await _incidentsRepo.SaveChangesAsync();

        return Ok();
    }
}
