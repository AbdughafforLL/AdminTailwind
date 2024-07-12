using Microsoft.AspNetCore.Mvc;
using MVC.Domain.DTOs.AccountDTOs;
using MVC.Domain.Entities;
using MVC.Domain.Enums;
using MVC.Domain.Wrappers;
using MVC.Infrastructure.Repositories.UserRepositories;
using System.Net;
namespace MVC.Infrastructure.Services.AccountServices;
public class AccountService(IUserRepository repository) : IAccountService
{
    public async Task<Response<User>> Login(LoginDto model)
    {
        try
        {
            var user = await repository.GetUserByUserName(model.UserName);
            if (user == null) return new Response<User> (HttpStatusCode.NotFound,"not found user");
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.HashPassword))
                return new Response<User> (HttpStatusCode.BadRequest, "Incorect password");
            return new Response<User> (user);
        }
        catch (Exception ex)
        {
            return new Response<User> (HttpStatusCode.InternalServerError,ex.Message);
        }
    }
    [HttpPost]
    public async Task<Response<bool>> Register(RegisterDto model)
    {
        try
        {
            var user = await repository.GetUserByUserName(model.UserName);
            if (user != null) return new Response<bool>(HttpStatusCode.BadRequest, "by username exist user");
            user = new User() {
                UserId = Guid.NewGuid().ToString(),
                Role = Roles.User.ToString(),
                UserName = model.UserName,
                HashPassword = BCrypt.Net.BCrypt.HashPassword(model.Password)
            };
            var res = await repository.AddUser(user);
            if (res) return new Response<bool>(true);
            return new Response<bool>(HttpStatusCode.InternalServerError,"server error");
        }
        catch (Exception ex)
        {
            return new Response<bool>(HttpStatusCode.InternalServerError,ex.Message);
        }
    }
}