using IncidentsApi.Data.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace IncidentsApi.Data.Repos.Implementations;

public class ContactsRepo : Interfaces.IContactsRepo
{
    private readonly ApplicationDbContext _context;
    public ContactsRepo(ApplicationDbContext context)
    {
        _context = context;
    }


    public ValueTask<EntityEntry<Contact>> AddAsync(Contact contact) => _context.Contacts.AddAsync(contact);
    public ValueTask<Contact?> FindAsync(string contactEmail) => _context.Contacts.FindAsync(contactEmail);
    public Task SaveChangesAsync() => _context.SaveChangesAsync();
}
