using System;

namespace CQRS
{
    public interface IHandlerFactory
    {
        ICommandHandler<TCommand> GetCommandHandler<TCommand>(Type commandType);
        IQueryHandler<IQuery<TResult>, TResult> GetQueryHandler<TResult>(Type queryType);
    }

    public class HandlerFactory : IHandlerFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public ICommandHandler<TCommand> GetCommandHandler<TCommand>(Type commandType)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(commandType);
            
            return _serviceProvider.GetService(handlerType) as ICommandHandler<TCommand>;
        }
        
        public IQueryHandler<IQuery<TResult>, TResult> GetQueryHandler<TResult>(Type queryType)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(queryType, typeof(TResult));
            
            return _serviceProvider.GetService(handlerType) as IQueryHandler<IQuery<TResult>, TResult>;
        }
    }
}