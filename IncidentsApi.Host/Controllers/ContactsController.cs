using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Interfaces;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class ContactsController : ControllerBase
{

    private readonly IContactsRepo _contactsRepo;
    public ContactsController(IContactsRepo contactsRepo)
    {
        _contactsRepo = contactsRepo;
    }

    [HttpPost("Create")]
    [ValidateAntiForgeryToken]
    public async ValueTask<IActionResult> Create([Bind("FistName", "LastName", "Email")] Contact contact)
    {
        Contact? contactInRepo = await _contactsRepo.FindAsync(contact.Email).ConfigureAwait(false);

        if (contactInRepo is null)
            await _contactsRepo.AddAsync(contact);

        await _contactsRepo.SaveChangesAsync();
        return Ok();
    }
}
