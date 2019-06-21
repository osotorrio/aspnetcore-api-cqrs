using System;

namespace CQRS
{
    public class SaveTodoCommandHandler : ICommandHandler<SaveTodoCommand>
    {
        public void Execute(SaveTodoCommand command)
        {
            Console.WriteLine($"[{command.DateLog.ToShortDateString()}]: {command.Todo}. User: {command.UserId}");
        }
    }
}