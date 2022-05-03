using System.ComponentModel.DataAnnotations;

namespace FakeOffice.ViewModels.Identity
{
    public class RegisterUserViewModel
    {

        [Required]
        [Display(Name ="Имя пользователя")]
        public string UserName { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]   
        [Display(Name ="Пароль")]
        public string Password { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare(nameof(Password),ErrorMessage ="Пароли не совпадают!")]
        public string PasswordConfirm { get; set; } = null!;

    }

}
