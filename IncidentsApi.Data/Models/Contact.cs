using System.ComponentModel.DataAnnotations;

namespace IncidentsApi.Data.Models;

public class Contact
{
    [Key, EmailAddress]
    public string Email { get; set; }


    public string FirstName { get; set; }
    public string LastName { get; set; }


    public string AccountName { get; set; }
    public Account? AccountNavigation { get; set; }

}