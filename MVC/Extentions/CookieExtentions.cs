using Microsoft.AspNetCore.Authentication.Cookies;

namespace MVC.Extentions;
public static class CookieExtentions
{
    public static void ConfigCookie(this IServiceCollection services)
    {
        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = "/Account/Login";
                });
        services.AddAuthorization();
    }
}
