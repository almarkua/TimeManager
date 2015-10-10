using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TimeManager.Models
{
    public class PublicCategory:ICategory
    {
        public int PublicCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public virtual IList<Case> Cases { get; set; }
        public virtual IList<User> Users { get; set; }

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
            ICategory tmp = obj as ICategory;
            if (tmp != null)
            {
                return Name.Equals(tmp.Name, StringComparison.CurrentCulture);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}