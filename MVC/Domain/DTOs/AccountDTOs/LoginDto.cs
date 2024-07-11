using System.ComponentModel.DataAnnotations;

namespace MVC.Domain.DTOs.AccountDTOs;
public class LoginDto
{
    [MaxLength(50, ErrorMessage = "Hjdksah"),
        Required(ErrorMessage = "Обязательно заполняйте имя пользователя")]
    public string UserName { get; set; } = null!;
    [MaxLength(50,ErrorMessage = "dsakhdalskjd"),
        Required(ErrorMessage = "Обязательно заполняйте пароль")]
    public string Password { get; set; } = null!;
}
