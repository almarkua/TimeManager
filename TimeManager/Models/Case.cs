using System;
using System.ComponentModel;

namespace TimeManager.Models
{
    public class Case
    {
        public int CaseId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public bool IsDone { get; set; }
        public virtual Category Category { get; set; }
    }
}