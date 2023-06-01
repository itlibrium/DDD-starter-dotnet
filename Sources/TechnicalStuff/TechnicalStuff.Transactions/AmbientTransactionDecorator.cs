using System.Threading.Tasks;
using System.Transactions;
using JetBrains.Annotations;
using MyCompany.ECommerce.TechnicalStuff.ProcessModel;

namespace MyCompany.ECommerce.TechnicalStuff.Transactions
{
    [PublicAPI]
    public class AmbientTransactionDecorator<TCommand> : CommandHandler<TCommand>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand> _decorated;

        public AmbientTransactionDecorator(CommandHandler<TCommand> decorated) => _decorated = decorated;

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
    public class AmbientTransactionDecorator<TCommand, TResult> : CommandHandler<TCommand, TResult>
        where TCommand : struct, Command
    {
        private readonly CommandHandler<TCommand, TResult> _decorated;

        public AmbientTransactionDecorator(CommandHandler<TCommand, TResult> decorated) => _decorated = decorated;

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