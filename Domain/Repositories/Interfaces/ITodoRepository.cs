using System;
using System.Collections.Generic;
using TODO_API.Domain.Entities;

namespace TODO_API.Domain.Repositories.Interfaces
{
    public interface ITodoRepository
    {
        void Create(Todo item);
        void Update(Todo item);
        void Delete(Todo item, Guid Id);
        Todo GetById(Guid id, string user);
        IList<Todo> GetAll(string user);
        IList<Todo> GetAllDone(string user);
        IList<Todo> GetAllUndone(string user);
        IList<Todo> GetByPeriod(string user, DateTime date, bool done);
           
    }
}