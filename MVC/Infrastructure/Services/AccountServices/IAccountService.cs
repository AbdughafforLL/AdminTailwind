using MVC.Domain.DTOs.AccountDTOs;
using MVC.Domain.Entities;
using MVC.Domain.Wrappers;
namespace MVC.Infrastructure.Services.AccountServices;
public interface IAccountService
{
    Task<Response<User>> Login(LoginDto model);
    Task<Response<bool>> Register(RegisterDto model);
}