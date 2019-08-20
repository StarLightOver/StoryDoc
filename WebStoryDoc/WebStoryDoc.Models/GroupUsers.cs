using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    class GroupUsers
    {
        public virtual ulong Id { set; get; }
        public virtual string Name { set; get; }
        public virtual IList<User> ListUser { set; get; } //Список участников группы

        public GroupUsers()
        {
            ListUser = new List<User>();
        }
    }
}
