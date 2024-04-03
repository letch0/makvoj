using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels;

public class RegisterVM
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Surname { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string? Password { get; set; }

    [Compare("Heslo", ErrorMessage = "Hesla se neshodují.")]
    [Display(Name = "Potvrďte heslo")]
    [DataType(DataType.Password)]
    [MinLength(8)]
    public string? ConfirmPassword { get; set; }
}
