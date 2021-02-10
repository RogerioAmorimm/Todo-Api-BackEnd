using TODO_API.Domain.Commands.Interfaces;

namespace TODO_API.Handlers.Interfaces
{
    public interface IHandler<T> where T : ICommand
    {
        ICommandResult Handle(T command);
    }
}