using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IncidentsApi.Data.Models;

public class Incident
{

    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }


    public string AccountName { get; set; }
    public Account AccountNavigation { get; set; }


}