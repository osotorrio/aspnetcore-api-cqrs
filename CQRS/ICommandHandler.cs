namespace CQRS
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }
}