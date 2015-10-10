﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeManager.Models
{
    public class Category:ICategory
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual User User { get; set; }
        public virtual IList<Case> Cases { get; set; }    
        
        public int CompareTo(ICategory other)
        {
            if (other != null)
            {
                return String.Compare(Name, other.Name, StringComparison.CurrentCulture);
            }
            return -1;
        }

        public override bool Equals(object obj)
        {
            var category = obj as Category;
            if (category != null)
            {
                return Name.Equals(category.Name);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
