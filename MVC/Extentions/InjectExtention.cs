using MVC.Infrastructure.Repositories.UserRepositories;
using MVC.Infrastructure.Services.AccountServices;
namespace MVC.Extentions;
public static class InjectExtention
{
    public static void InjectServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountService, AccountService>();
    }
    public static void InjectRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
    }
}