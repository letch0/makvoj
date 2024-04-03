using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.ViewModels;

public class LoginVM
{
    [Required(ErrorMessage ="Vyplňte uživatelské jméno.")]
    public string? Username { get; set; }

    [Required(ErrorMessage ="Nutné heslo.")]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Display(Name ="Pamatovat si mě")]
    public bool RememberMe { get; set; }
}
