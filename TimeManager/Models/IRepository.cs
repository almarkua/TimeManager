using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Context;

namespace TimeManager.Models
{
    public interface IRepository
    {
        IList<User> Users { get; }

        void AddTodo(Category cat, Todo todo);
        void UpdateTodo(User currentUser, Todo oldTodo,Todo newTodo);
        void RemoveTodo(Todo todo);

        void AddCategory(User currentUser, Category cat);
        void UpdateCategory(User currentUser, Category cat);
        void DeleteCategory(User currentUser, Category cat);
    }
}
