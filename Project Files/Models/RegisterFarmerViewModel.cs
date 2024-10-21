using System.ComponentModel.DataAnnotations;

public class RegisterFarmerViewModel
{
    [Required]
    [Display(Name = "Full Name")]
    public string FullName { get; set; }

    [Required]
    [EmailAddress]
    [Display(Name = "Email")]
    public string Email { get; set; }

    [Required]
    [Display(Name = "Password")]
    public string Password { get; set; }
}
