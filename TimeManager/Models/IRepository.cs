using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public interface IRepository
    {
        List<User> Users { get; }
        void AddUser(User newUser);
        void RemoveUser(User user);
    }
}
