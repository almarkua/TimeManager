using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeManager.Models
{
    public class TimeManagerModel
    {
        public List<Case> Cases { get; set; }
        public NewCase NewCase { get; set; }
        public List<int> Priorities { get; set; }
        public List<Category> Categories { get; set; }

        public TimeManagerModel()
        {
            NewCase = new NewCase();
            Categories = new List<Category>();
            Cases = GetCases();
            Priorities = new List<int>() {1,2,3,4,5};
        }

        public List<Case> GetCases()
        {

            List<Case> resultList = new List<Case>();
            Category category = new Category()
            {
                Name = "Тестова категорія",
                Description = "Опис категорії"
            };
            Categories.Add(category);
            resultList.Add(new Case()
            {
                ShortDescription = "Справа 1",
                Description = "Опис",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Priority = 1,
                Category = category
            });
            resultList.Add(new Case()
            {
                ShortDescription = "Справа 2",
                Description = "Опис",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Priority = 1,
                Category = category
            });
            resultList.Add(new Case()
            {
                ShortDescription = "Справа 3",
                Description = "Опис",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(1),
                Priority = 1,
                Category = category
            });
            return resultList;
        }
    }
}