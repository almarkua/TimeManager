using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeManager.Models
{
    public class TodosModel
    {
        public List<Todo> TodaysTodos { get; set; }
        public List<Todo> FutureTodos { get; set; }

        public TodosModel()
        {
            TodaysTodos = new List<Todo>();
            FutureTodos = new List<Todo>();
        }
    }
}