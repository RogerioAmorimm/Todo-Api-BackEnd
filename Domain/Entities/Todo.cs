using System;

namespace TODO_API.Domain.Entities
{
    public class Todo : Entity
    {

        public Todo(string title, DateTime date, string user)
        {
            Title = title;
            Date = date;
            User = user;
            Done = false;
        }

        public string Title { get; private set; }
        public bool Done { get; private set; }
        public DateTime Date { get; private set; }
        public string User { get; private set; }

        public void MarkAsUndone() { this.Done = false; }
        public void MarkAsDone() { this.Done = true; }

        public void UpdateTitle(string NewTitle)
        {
            this.Title =  NewTitle;
        }
        

    }

}