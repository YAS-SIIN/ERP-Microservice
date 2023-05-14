using ERP.Infra.Data.CoreContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace ERP.IoC;

public static class AddAppConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MAIN_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:MAIN_ERPConnectionString"]));
        //builder.Services.AddDbContext<MyDataBase>(options => options.UseInMemoryDatabase("MyDB"));
    }

}
