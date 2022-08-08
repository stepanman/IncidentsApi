using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class ContactsRepo : Abstractions.IContactsRepo
{
    private readonly ApplicationDbContext _context;
    public ContactsRepo(ApplicationDbContext context)
    {
        _context = context;
    }


    public ValueTask<EntityEntry<Contact>> AddAsync(Contact contact) => _context.Contacts.AddAsync(contact);
    public async ValueTask<bool> ExistsAsync(Contact contact) => (await GetByEmailAsync(contact.Email)) is not null;
    public async ValueTask<bool> IsLinkedAsync(Contact contact) => (await GetByEmailAsync(contact.Email))?.AccountNavigation is not null;
    public void Update(Contact contact) => _context.Contacts.Update(contact);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();


    private Task<Contact> GetByEmailAsync(string contactEmail) => _context.Contacts.AsNoTracking().FirstOrDefaultAsync(contact => contact.Email == contactEmail);
}
