﻿

using ERP.Application.Behaviors;
using ERP.Domain.Interfaces.UnitOfWork;
using ERP.Infra.Data.CoreContext;
using ERP.Infra.Data.UnitOfWork;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation.Validators;
using FluentValidation;

using System.Reflection;
using ERP.Infra.Messaging;
using ERP.Presentation.Shared.Tools;
using Microsoft.EntityFrameworkCore.Storage;

namespace ERP.IoC;
public static class ServerConfiguration
{
    private static readonly InMemoryDatabaseRoot inMemoryDatabaseRoot = new InMemoryDatabaseRoot();
    public static void Register(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MAIN_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:MAIN_ERPConnectionString"]));
        services.AddDbContext<READ_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:READ_ERPConnectionString"]));
        services.AddDbContext<WRITE_ERPDBContext>(options => options.UseSqlServer(configuration["ApplicationOptions:WRITE_ERPConnectionString"]));

        // services.AddDbContext<MAIN_ERPDBContext>(options => options.UseInMemoryDatabase("ERPDbContext", inMemoryDatabaseRoot));
        // services.AddDbContext<READ_ERPDBContext>(options => options.UseInMemoryDatabase("ERPDbContext", inMemoryDatabaseRoot));
        // services.AddDbContext<WRITE_ERPDBContext>(options => options.UseInMemoryDatabase("ERPDbContext", inMemoryDatabaseRoot));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IBus, Bus>();
        services.AddScoped<ISecurity, Security>();
        services.AddScoped<CoreDBContextInjection>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ERP.Application.InjectApplication).GetTypeInfo().Assembly));
        services.AddValidatorsFromAssembly(typeof(ERP.Core.InjectCore).GetTypeInfo().Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnhandledExceptionBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
