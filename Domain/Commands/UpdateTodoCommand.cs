using Flunt.Validations;
using Flunt.Notifications;
using TODO_API.Domain.Commands.Interfaces;
using System;

namespace TODO_API.Domain.Commands
{
    public class UpdateTodoCommand : Notifiable, ICommand
    {
        public UpdateTodoCommand()
        {

        }

        public UpdateTodoCommand(Guid id, string user, string title)
        {
            this.id = id;
            User = user;
            Title = title;
        }

        public Guid id { get; set; }
        public string User { get; set; }
        public string Title { get; set; }
        public void Validate()
        {
            AddNotifications(new Contract()
                            .Requires()
                            .HasMinLen(this.Title, 3, "Title", "Por favor, descreva melhor esta tarefa")
                            .HasMinLen(this.User, 6, "User", "Usuário inválido")); 
        }
    }
}