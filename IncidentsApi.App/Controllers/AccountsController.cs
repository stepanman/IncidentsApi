using Microsoft.AspNetCore.Mvc;
using IncidentsApi.Data.Repos.Abstractions;
using IncidentsApi.Data.Models;
using System.Net.Mime;

namespace IncidentsApi.App.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountsController : ControllerBase
{
    private readonly IAccountsRepo _accountsRepo;
    public record CreateAccountRequestBody(
        string AccountName,
        string ContactEmail,
        string ContactFirstName,
        string ContactLastName
    );

    public AccountsController(IAccountsRepo accountsRepo)
    {
        _accountsRepo = accountsRepo;
    }


    [HttpPost("Create")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]

    public async ValueTask<IActionResult> Create(
        [FromServices] IContactsRepo contactsRepo,
        CreateAccountRequestBody body
    )
    {
        Account account = new() { Name = body.AccountName };
        Contact contact = new() { Email = body.ContactEmail, FirstName = body.ContactFirstName, LastName = body.ContactLastName };

        if (!TryValidateModel(account) || !TryValidateModel(contact))
            return BadRequest(ModelState);


        if (await _accountsRepo.ExistsAsync(account))
            return Conflict();

        if (await contactsRepo.ExistsAsync(contact))
        {
            if (await contactsRepo.IsLinkedAsync(contact))
                return Conflict();
            else
                contactsRepo.Update(contact);
        }

        account.Contacts.Add(contact);
        await _accountsRepo.AddAsync(account);
        await _accountsRepo.SaveChangesAsync();
        return Ok();
    }
}
