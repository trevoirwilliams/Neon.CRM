namespace Neon.CRM.WebApp.Data.Models;

public class Booking
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    public int VacationPackageId { get; set; }
    public DateTime BookingDate { get; set; }
    public bool IsConfirmed { get; set; }

    // Navigation properties
    public Customer? Customer { get; set; }
    public VacationPackage? VacationPackage { get; set; }
}