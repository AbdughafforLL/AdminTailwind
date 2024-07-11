using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MVC.Domain.DTOs.AccountDTOs;
using MVC.Infrastructure.Services.AccountServices;
using System.Security.Claims;
using MVC.Domain.Enums;
namespace MVC.Controllers;
public class AccountController(IAccountService service) : Controller
{
    public IActionResult Profile() => View();
    public IActionResult Login()=> View();
    public IActionResult Register() => View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginDto model)
    {
        if (!ModelState.IsValid) { 
            return View();
        }
        var res = await service.Login(model);
        if (res.StatusCode != 200) {
            ViewBag.Message = res.Errors;
            return View();
        }

        var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name,res.Data.UserName),
                new Claim(ClaimTypes.Role,res.Data.Role)
        };
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties()
        {
            AllowRefresh = true,
            IsPersistent = true,
            ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
        };
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties
        );

        if(res.Data.Role == Roles.User.ToString())
            return RedirectToAction("Index", "Home");
        return RedirectToAction("Index", "Admin");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterDto model)
    {
        if (!ModelState.IsValid)
            return View();

        var res = await service.Register(model);
        if (res.StatusCode != 200)
        {
            ViewBag.Message = res.Errors;
            return View();
        }
        return RedirectToAction("Login","Account");
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Login","Account");
    }
}