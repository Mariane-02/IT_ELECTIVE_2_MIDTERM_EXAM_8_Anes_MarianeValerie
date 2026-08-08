using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.Models;

public class User
{
    public int Id { get; set; }

    [Required, Display(Name = "First Name"), StringLength(50)]
    public string FirstName { get; set; } = "";

    [Required, Display(Name = "Last Name"), StringLength(50)]
    public string LastName { get; set; } = "";

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; } = "";

    [Required, Display(Name = "Username"), StringLength(50)]
    public string Username { get; set; } = "";

    [Required, DataType(DataType.Password), StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = "";
}
