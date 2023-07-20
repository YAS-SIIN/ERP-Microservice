

using ERP.Common.Behaviours;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.CoreContext;
using ERP.Infra.Data.UnitOfWork;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System.Reflection;

namespace ERP.IoC;

public static class APIConfiguration
{
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MAIN_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:MAIN_ERPConnectionString"]));
        services.AddDbContext<READ_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:READ_ERPConnectionString"]));
        services.AddDbContext<WRITE_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:WRTIE_ERPConnectionString"]));
       
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<CoreDBContextInjection>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ERP.Application.InjectMediatR).GetTypeInfo().Assembly));

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehaviour<,>));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));

    }

}
