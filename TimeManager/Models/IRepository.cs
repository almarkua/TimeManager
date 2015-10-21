using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeManager.Context;

namespace TimeManager.Models
{
    public interface IRepository
    {
        IList<User> Users { get; }
        IList<PublicCategory> PublicCategories { get; }
    }
}
