using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TimeManager.App_Start;
using TimeManager.Context;

namespace TimeManager.Models
{
    public class MainRepository:IRepository
    {
        private readonly MainContext _context;

        public MainRepository()
        {
            _context = new MainContext();
        }

        public IList<User> Users {
            get { return _context.Users.ToList();  }
        }

        public void AddTodo(Category cat, Todo todo)
        {
            cat.Todos.Add(todo);
            _context.SaveChanges();
        }

        public void UpdateTodo(User currentUser, Todo oldTodo,Todo newTodo)
        {
            /*
            var cTodo =
                _context.Users.First(u => u.UserId == currentUser.UserId)
                    .Categories.First(cat => cat.CategoryId == oldTodo.Category.CategoryId)
                    .Todos.First(todo => todo.TodoId == oldTodo.TodoId);
            */
            if (oldTodo.Category.CategoryId != newTodo.Category.CategoryId)
            {
                oldTodo.Category.Todos.Remove(oldTodo);
                newTodo.Category.Todos.Add(newTodo);
            }
            else
            {
                oldTodo.ShortDescription = newTodo.ShortDescription;
                oldTodo.Description = newTodo.Description;
                oldTodo.StartDate = newTodo.StartDate;
                oldTodo.IsDone = newTodo.IsDone;
                oldTodo.EndDate = newTodo.EndDate;
                oldTodo.Priority = newTodo.Priority;
            }
            _context.SaveChanges();
        }

        public void RemoveTodo(Todo todo)
        {
            _context.Users.First(x => todo.Category.User.UserId == x.UserId)
                .Categories.First(cat => cat.CategoryId == todo.Category.CategoryId)
                .Todos.Remove(todo);
            _context.SaveChanges();
        }

        public void AddCategory(User currentUser, Category cat)
        {
            currentUser.Categories.Add(cat);
            _context.SaveChanges();
        }

        public void UpdateCategory(User currentUser, Category cat)
        {
            var tmpCat = currentUser.Categories.First(x => x.CategoryId == cat.CategoryId);
            tmpCat.Name = cat.Name;
            tmpCat.Description = cat.Description;
            _context.SaveChanges();
        }

        public void DeleteCategory(User currentUser, Category cat)
        {
            currentUser.Categories.Remove(cat);
            _context.SaveChanges();
        }

    }
}