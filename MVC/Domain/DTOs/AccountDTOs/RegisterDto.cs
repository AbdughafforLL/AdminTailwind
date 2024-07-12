using System.ComponentModel.DataAnnotations;
namespace MVC.Domain.DTOs.AccountDTOs;
public class RegisterDto
{
    [MaxLength(50, ErrorMessage = "hdsjkahdk"),
        Required(ErrorMessage = "Обязательно заполните имя ползователья")]
    public string UserName { get; set; } = null!;
    [MaxLength(50,ErrorMessage = "dhsjkadhkjas"),
        Required(ErrorMessage = "Обязательно заполните пароль")]
    public string Password { get; set; } = null!;
    [MaxLength(50,ErrorMessage = "hdjksahdas"),
        Required(ErrorMessage = "Обязательно Подтвердите пароль"),
        Compare("Password",ErrorMessage = "Пароль не совпадаеть")]
    public string ConfirmPassword { get; set; } = null!;
}