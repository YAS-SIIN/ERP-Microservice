using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleLibrary.Infra.Data.Context;

namespace ERP.IoC;

public static class AddAppConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ERPDbContext>(options => options.UseSqlServer(configuration["ApplicationOptions:ConnectionString"]));
        //builder.Services.AddDbContext<MyDataBase>(options => options.UseInMemoryDatabase("MyDB"));
    }

}
