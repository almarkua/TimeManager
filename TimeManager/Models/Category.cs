using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace TimeManager.Models
{
    public class Category : IComparable<Category>
    {
        public int CategoryId { get; set; }
        [DisplayName("Назва")]
        public string Name { get; set; }
        [DisplayName("Опис")]
        public string Description { get; set; }
        
        public virtual User User { get; set; }
        public virtual IList<Todo> Todos { get; set; }    
        
        public int CompareTo(Category other)
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
