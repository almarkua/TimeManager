using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeManager.Models
{
    public class MainRepository : DbContext, IRepository
    {
        public DbSet<User> UsersDbSet { get; set; }

        public DbSet<PublicCategory> PublicCategoriesDbSet { get; set; }

        public MainRepository()
        {
            Console.WriteLine("MainRepository creating");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.PublicCategories)
                .WithMany(category => category.Users)
                .Map(u => u.MapLeftKey("UserId").MapRightKey("CategotyId").ToTable("UsersPublicCategories"));
        }

        public IList<User> Users
        {
            get { return UsersDbSet.ToList(); }
        }

        public IList<PublicCategory> PublicCategories {
            get { return PublicCategories.ToList();}
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

        public void AddPublicCategory(PublicCategory category)
        {
            PublicCategoriesDbSet.Add(category);
            SaveChanges();
        }

    }
}