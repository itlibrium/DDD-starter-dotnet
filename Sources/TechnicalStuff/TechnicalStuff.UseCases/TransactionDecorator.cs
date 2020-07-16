using System.Threading.Tasks;
using System.Transactions;
using JetBrains.Annotations;

namespace MyCompany.Crm.TechnicalStuff.UseCases
{
    [PublicAPI]
    public class TransactionDecorator<TCommand> : CommandHandler<TCommand>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand> _decorated;

        public TransactionDecorator(CommandHandler<TCommand> decorated) => _decorated = decorated;

        public async Task Handle(TCommand command)
        {
            using var scope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted},
                TransactionScopeAsyncFlowOption.Enabled);
            await _decorated.Handle(command);
            scope.Complete();
        }
    }
    
    [PublicAPI]
    public class TransactionDecorator<TCommand, TResult> : CommandHandler<TCommand, TResult>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand, TResult> _decorated;

        public TransactionDecorator(CommandHandler<TCommand, TResult> decorated) => _decorated = decorated;

        public async Task<TResult> Handle(TCommand command)
        {
            using var scope = new TransactionScope(
                TransactionScopeOption.RequiresNew,
                new TransactionOptions {IsolationLevel = IsolationLevel.ReadCommitted},
                TransactionScopeAsyncFlowOption.Enabled);
            var result = await _decorated.Handle(command);
            scope.Complete();
            return result;
        }
    }
}