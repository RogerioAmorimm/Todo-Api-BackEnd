using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TODO_API.Domain.Data;
using TODO_API.Domain.Entities;
using TODO_API.Domain.Repositories.Interfaces;

namespace TODO_API.Domain.Repositories
{

    public class TodoRepository : ITodoRepository
    {
        private readonly DataContext _context;

        public TodoRepository(DataContext context)
        {
            _context = context;
        }

        public void Create(Todo item)
        {
            this._context.Todos.Add(item);
            this._context.SaveChanges();

        }

        public void Delete(Todo item, Guid Id)
        {
            var todo = this._context.Todos.FirstOrDefault(x => x.Id == Id && x.User == item.User && x.Title == item.Title);
            if (todo != null) this._context.Todos.Remove(todo);

            this._context.SaveChanges();
            
        }

        public IList<Todo> GetAll(string user)
        {
            var todosByUser = this._context
                                .Todos
                                .AsNoTracking()
                                .Where(x => x.User == user)
                                .OrderBy(x => x.Date).ToList();
            return todosByUser;
        }

        public IList<Todo> GetAllDone(string user)
        {
            var todosByUser = this._context
                                .Todos
                                .AsNoTracking()
                                .Where(x => x.User == user && x.Done)
                                .OrderBy(x => x.Date).ToList();
            return todosByUser;
        }

        public IList<Todo> GetAllUndone(string user)
        {
            var todosByUser = this._context
                               .Todos
                               .AsNoTracking()
                               .Where(x => x.User == user && x.Done == false)
                               .OrderBy(x => x.Date).ToList();
            return todosByUser;
        }

        public Todo GetById(Guid id, string user)
        {
            var todoUser = this._context
                            .Todos
                            .FirstOrDefault(x => x.User == user && x.Id == id);

            return todoUser;
        }

        public IList<Todo> GetByPeriod(string user, DateTime date, bool done)
        {
            var todosByUser = this._context
                                .Todos
                                .AsNoTracking()
                                .Where(x => x.User == user && x.Date.Date == date.Date)
                                .OrderBy(x => x.Date).ToList();
            return todosByUser;
        }

        public void Update(Todo item)
        {
            this._context.Entry(item).State = EntityState.Modified;
            this._context.SaveChanges();
        }
    }
}