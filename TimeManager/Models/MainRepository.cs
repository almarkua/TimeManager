using System;
using System.Collections.Generic;
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
        public IList<PublicCategory> PublicCategories {
            get { return _context.PublicCategories.ToList(); }
        }
    }
}