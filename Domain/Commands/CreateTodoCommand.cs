using System;
using TODO_API.Domain.Commands.Interfaces;
using Flunt.Notifications;
using Flunt.Validations;

namespace TODO_API.Domain.Commands
{
    public class CreateTodoCommand : Notifiable, ICommand
    {
        public CreateTodoCommand()
        {

        }

        public CreateTodoCommand(string tilte, string user, DateTime date)
        {
            Title = tilte;
            User = user;
            Date = date;
        }

        public string Title { get; set; }

        public string User { get; set; }

        public DateTime Date { get; set; }

        public void Validate()
        {
            AddNotifications(new Contract()
                            .Requires()
                            .HasMinLen(this.Title, 3, "Title", "Por favor, descreva melhor esta tarefa")
                            .HasMinLen(this.User, 6, "User", "Usuário inválido"));       
        }
    }
}