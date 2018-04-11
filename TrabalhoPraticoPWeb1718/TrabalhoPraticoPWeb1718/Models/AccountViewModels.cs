using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TrabalhoPraticoPWeb1718.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra-passe")]
        public string Password { get; set; }

        [Display(Name = "Lembrar conta?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(50, ErrorMessage = "O tamanho do nome da conta deverá estar entre 10 a 50 caracteres!", MinimumLength = 10)]
        [Display(Name = "Nome da conta")]
        public string UserName { get; set; }

        [Display(Name = "Perfil")]
        public string OptionRole { get; set; }
        public System.Web.Mvc.SelectList RolesList { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Não é um endereço de e-mail válido!")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter, pelo menos, {2} caracteres!", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Palavra-passe")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Palavra-passe")]
        [Compare("Password", ErrorMessage = "As Palavras-passe são diferentes!")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
