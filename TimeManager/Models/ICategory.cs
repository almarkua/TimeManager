using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeManager.Models
{
    public interface ICategory:IComparable<ICategory>
    {
        string Name { get; set; }
        string Description { get; set; }

        IList<Case> Cases { get; set; }
    }
}
