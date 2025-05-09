using System.ComponentModel.DataAnnotations;

namespace MVC.Intro.Models;

public class AddBookDto
{
    [Required]
    [StringLength(6)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(10, MinimumLength = 5)]
    [DataType(DataType.Password)]
    // suitable input is <input type="password"/>
    public string Password { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
}
