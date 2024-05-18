using System.Reflection;
using MyCompany.ECommerce.TechnicalStuff.Outbox;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;
using MyCompany.ECommerce.TechnicalStuff.Transactions;

namespace MyCompany.ECommerce.DI;

public static class CrossCuttingConcerns
{
    public static IServiceCollection AddOutboxesRegistry(this IServiceCollection services)
    {
        services.AddScoped<TransactionalOutboxes>();
        services.AddScoped<NonTransactionalOutboxes>();
        return services;
    }
        
    public static IServiceCollection AddMessageOutboxes(this IServiceCollection services,
        params Assembly[] assemblies)
    {
        services.Scan(selector => selector
            .FromAssemblies(assemblies)
            .AddClasses(filter => filter
                .AssignableToAny(typeof(TransactionalOutbox), typeof(NonTransactionalOutbox)))
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        // TODO: registering types
        services.AddSingleton<MessageTypes>();
        return services;
    }

    public static IServiceCollection DecorateCommandHandlers(this IServiceCollection services)
    {
        services.TryDecorate(typeof(CommandHandler<>), typeof(TransactionalMessageSendingDecorator<>));
        services.TryDecorate(typeof(CommandHandler<,>), typeof(TransactionalMessageSendingDecorator<,>));
        services.TryDecorate(typeof(CommandHandler<>), typeof(AmbientTransactionDecorator<>));
        services.TryDecorate(typeof(CommandHandler<,>), typeof(AmbientTransactionDecorator<,>));
        services.TryDecorate(typeof(CommandHandler<>), typeof(NonTransactionalMessageSendingDecorator<>));
        services.TryDecorate(typeof(CommandHandler<,>), typeof(NonTransactionalMessageSendingDecorator<,>));
        return services;
    }
}