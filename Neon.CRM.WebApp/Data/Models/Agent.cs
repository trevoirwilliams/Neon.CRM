using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Neon.CRM.WebApp.Data.Models;

public class Agent : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    // Navigation property
    public ICollection<Customer> Customers { get; set; } = [];
}
