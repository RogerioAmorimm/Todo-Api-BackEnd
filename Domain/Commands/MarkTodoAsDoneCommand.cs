using Flunt.Validations;
using Flunt.Notifications;
using TODO_API.Domain.Commands.Interfaces;
using System;

namespace TODO_API.Domain.Commands
{
    public class MarkTodoAsDoneCommand : Notifiable, ICommand
    {
        public MarkTodoAsDoneCommand()
        {

        }

        public MarkTodoAsDoneCommand(Guid id, string user)
        {
            this.id = id;
            User = user;
        }

        public Guid id { get; set; }
        public string User { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract().Requires().HasMinLen(this.User, 6, "User", "Usuário inválido"));
        }
    }
}