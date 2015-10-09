using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeManager.Models
{
    public class Category:IComparable<Category>
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual User User { get; set; }

        public virtual IList<Case> Cases { get; set; }
        
        public int CompareTo(Category other)
        {
            return String.Compare(Name, other.Name, StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            if (obj != null && obj is Category)
            {
                return Name.Equals(((Category) obj).Name);
            }
            return false;
        }
    }
}
