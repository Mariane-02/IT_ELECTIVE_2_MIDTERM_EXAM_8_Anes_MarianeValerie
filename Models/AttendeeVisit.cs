using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;

public class AttendeeVisit
{
    public int Id { get; set; }

    [Required, Display(Name = "Ticket Number"), StringLength(30)]
    public string TicketNumber { get; set; } = "";

    [Required, Display(Name = "First Name"), StringLength(50)]
    public string FirstName { get; set; } = "";

    [Required, Display(Name = "Last Name"), StringLength(50)]
    public string LastName { get; set; } = "";

    [Required, Display(Name = "Company/School"), StringLength(100)]
    public string Organization { get; set; } = "";

    [Required, Display(Name = "Contact Number"), Phone, StringLength(30)]
    public string ContactNumber { get; set; } = "";

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = "";

    [Required, Display(Name = "Event Name"), StringLength(100)]
    public string EventName { get; set; } = "";

    [Display(Name = "Check-In Time"), DataType(DataType.DateTime)]
    public DateTime CheckInTime { get; set; }

    [Display(Name = "Check-Out Time"), DataType(DataType.DateTime)]
    public DateTime? CheckOutTime { get; set; }

    [Required, StringLength(30)]
    public string Status { get; set; } = "Present";

    [StringLength(500)]
    public string? Notes { get; set; }
}
