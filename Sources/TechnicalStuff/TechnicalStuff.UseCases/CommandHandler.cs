using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases
{
    public interface CommandHandler { }
    
    public interface CommandHandler<in TCommand> : CommandHandler
        where TCommand : struct, Command
    {
        Task Handle(TCommand command);
    }
    
    public interface CommandHandler<in TCommand, TResult> : CommandHandler
        where TCommand : struct, Command
    {
        Task<TResult> Handle(TCommand command);
    }
}