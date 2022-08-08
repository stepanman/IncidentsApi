using System.ComponentModel.DataAnnotations;

namespace IncidentsApi.Data.Models;

public class Contact
{
    [Key, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }


    public string AccountName { get; set; }
    public Account AccountNavigation { get; set; }

}