using Flunt.Notifications;
using TODO_API.Domain.Commands;
using TODO_API.Domain.Commands.Interfaces;
using TODO_API.Domain.Entities;
using TODO_API.Domain.Repositories.Interfaces;
using TODO_API.Handlers.Interfaces;

namespace TODO_API.Domain.Handlers
{
    public class TodoHandler :
     Notifiable,
     IHandler<CreateTodoCommand> ,
     IHandler<UpdateTodoCommand> ,
     IHandler<MarkTodoAsDoneCommand> ,
     IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid) return new GenericCommandResult(false, "Tarefa está invalida", command.Notifications);
            
            var NewItem = new Todo(command.Title, command.Date, command.User);

            this._repository.Create(NewItem);

            return  new GenericCommandResult(true, "Tarefa salva", NewItem);

        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();

            if (command.Invalid) return new GenericCommandResult(false, "Tarefa está invalida", command.Notifications);

            var item  = this._repository.GetById(command.id, command.User);

            item.UpdateTitle(item.Title);

            this._repository.Update(item);
             
            return new GenericCommandResult(true, "Tarefa Modificada", item);
            
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            
            command.Validate();

            if (command.Invalid) return new GenericCommandResult(false, "Tarefa está invalida", command.Notifications);

            var item  = this._repository.GetById(command.id, command.User);

            item.MarkAsUndone();

            this._repository.Update(item);
             
            return new GenericCommandResult(true, "Tarefa marcada como não comcluida", item);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
           
            command.Validate();

            if (command.Invalid) return new GenericCommandResult(false, "Tarefa está invalida", command.Notifications);

            var item  = this._repository.GetById(command.id, command.User);

            item.MarkAsDone();

            this._repository.Update(item);
             
            return new GenericCommandResult(true, "Tarefa marcada como comcluida", item);
        }
    }
}