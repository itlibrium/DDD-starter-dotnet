using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using MyCompany.Crm.TechnicalStuff.UseCases;
using MyCompany.Crm.TechnicalStuff.UseCases.Messages;
using MyCompany.Crm.TechnicalStuff.UseCases.Transactions;

namespace MyCompany.Crm.DI
{
    public static class CrossCuttingConcerns
    {
        public static IServiceCollection AddOutboxesRegistry(this IServiceCollection services)
        {
            services.AddScoped<TransactionalOutboxes>();
            services.AddScoped<NonTransactionalOutboxes>();
            return services;
        }
        
        public static IServiceCollection AddMessageOutboxes(this IServiceCollection services,
            params Assembly[] assemblies) =>
            services.Scan(selector => selector
                .FromAssemblies(assemblies)
                .AddClasses(filter => filter
                    .AssignableToAny(typeof(TransactionalOutbox), typeof(NonTransactionalOutbox)))
                .AsSelfWithInterfaces()
                .WithScopedLifetime());
        
        public static IServiceCollection DecorateCommandHandlers(this IServiceCollection services)
        {
            services.TryDecorate(typeof(CommandHandler<>), typeof(TransactionalMessageSendingDecorator<>));
            services.TryDecorate(typeof(CommandHandler<,>), typeof(TransactionalMessageSendingDecorator<,>));
            services.TryDecorate(typeof(CommandHandler<>), typeof(TransactionDecorator<>));
            services.TryDecorate(typeof(CommandHandler<,>), typeof(TransactionDecorator<,>));
            services.TryDecorate(typeof(CommandHandler<>), typeof(NonTransactionalMessageSendingDecorator<>));
            services.TryDecorate(typeof(CommandHandler<,>), typeof(NonTransactionalMessageSendingDecorator<,>));
            return services;
        }
    }
}