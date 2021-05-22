using System.Threading.Tasks;

namespace MyCompany.Crm.TechnicalStuff.UseCases
{
    public interface CommandHandler
    {
        Task Handle(Command command);
    }

    public interface CommandHandler<in TCommand> : CommandHandler
        where TCommand : Command
    {
        Task CommandHandler.Handle(Command command)
        {
            if (!(command is TCommand tCommand))
                throw new DesignError($"{command.GetType().Name} in incompatible with {GetType().Name}");
            return Handle(tCommand);
        }

        Task Handle(TCommand command);
    }

    public interface CommandHandler<in TCommand, TResult> : CommandHandler<TCommand>
        where TCommand : Command
    {
        Task CommandHandler<TCommand>.Handle(TCommand command) => Handle(command);

        new Task<TResult> Handle(TCommand command);
    }
}