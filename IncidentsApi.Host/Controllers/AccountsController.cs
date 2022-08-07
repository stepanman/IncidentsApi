using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Interfaces;
using IncidentsApi.Data.Models;

namespace IncidentsApi.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountsRepo _accountsRepo;

    public AccountsController(IAccountsRepo accountsRepo)
    {
        _accountsRepo = accountsRepo;
    }


    [HttpPost("Create")]
    [ValidateAntiForgeryToken]

    public async ValueTask<IActionResult> Create(
        [FromServices] IContactsRepo contactsRepo,
        [Bind("Name", Prefix = "Account")] Account accountFromRequest,
        [Bind("FirstName", "LastName", "Email", Prefix = "Contact")] Contact contactFromRequest
    )
    {
        Account? accountInRepo = await _accountsRepo.FindAsync(accountFromRequest.Name);
        if (accountInRepo is not null)
            return Conflict($"Account {accountFromRequest.Name} already exists");

        Contact? contactInRepo = await contactsRepo.FindAsync(contactFromRequest.Email);
        if (contactInRepo is not null)
        {
            if (contactInRepo.AccountNavigation is not null)
                return Conflict($"Contact {contactFromRequest.Email} is linked to another account");
            else
            {
                contactInRepo.LastName = contactFromRequest.LastName;
                contactInRepo.FirstName = contactFromRequest.FirstName;
                contactInRepo.AccountNavigation = accountFromRequest;
                await _accountsRepo.SaveChangesAsync();
                return Ok();
            }
                
        }


        accountFromRequest.Contacts.Add(contactFromRequest);
        await _accountsRepo.AddAsync(accountFromRequest);
        return Ok();
    }
}
