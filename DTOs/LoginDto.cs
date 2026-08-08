using System.ComponentModel.DataAnnotations;

namespace IT_ELECTIVE_2_MIDTERM_EXAM_8_Anes_MarianeValerie.DTOs;

public class LoginDto
{
    [Required, Display(Name = "Username")]
    public string Username { get; set; } = "";

    [Required, DataType(DataType.Password)]
    public string Password { get; set; } = "";
}
