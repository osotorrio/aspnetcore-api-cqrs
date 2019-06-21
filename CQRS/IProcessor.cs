using System;

namespace CQRS
{
    public interface IProcessor
    {
        void Process(ICommand command);
        TResult Process<TResult>(IQuery<TResult> query);
    }

    public class Processor : IProcessor
    {
        private readonly IServiceProvider _serviceProvider;

        public Processor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Process(ICommand command)
        {
            var handlerType = typeof(ICommandHandler<>).MakeGenericType(command.GetType());
            
            dynamic handler = _serviceProvider.GetService(handlerType);

            handler.Execute((dynamic)command);
        }

        public TResult Process<TResult>(IQuery<TResult> query)
        {
            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            
            dynamic handler = _serviceProvider.GetService(handlerType);

            return handler.Execute((dynamic)query);
        }
    }
}