using Lab5.Application.Abstractions.Persistence;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Contracts.Histories;
using Lab5.Application.Contracts.Sessions;
using Lab5.Application.Services;
using Lab5.Domain.ValueObjects;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection collection, IConfiguration configuration)
    {
        collection.AddScoped<IAccountService, AccountService>();
        collection.AddScoped<IHistoryService, HistoryService>();

        string systemPassword = configuration["SystemPassword:Value"]
                                ?? throw new ArgumentException("Error: SystemPassword is not configured");

        collection.AddScoped<ISessionService>(sp =>
        {
            IPersistenceContext context = sp.GetService<IPersistenceContext>();
            return new SessionService(context, new Password(systemPassword));
        });

        return collection;
    }
}