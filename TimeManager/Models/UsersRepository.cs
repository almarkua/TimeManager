using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeManager.Models
{
    public class UsersRepository:DbContext,IRepository
    {
        private DbSet<User> UsersDbSet { get; set; }

        public List<User> Users
        {
            get { return UsersDbSet.ToList(); }
        }

        public void AddUser(User newUser)
        {
            UsersDbSet.Add(newUser);
            SaveChanges();
        }

        public void RemoveUser(User user)
        {
            UsersDbSet.Remove(user);
            SaveChanges();
        }

    }
}