using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class GroupUsers
    {
        public virtual ulong Id { set; get; }
        public virtual string Name { set; get; }
        public virtual IList<User> ListUser { set; get; } //Список участников группы

        public GroupUsers()
        {
            ListUser = new List<User>();
        }
    }

    public class GroupUsersMap : ClassMap<GroupUsers>
    {
        public GroupUsersMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.Name).Length(100);
            HasMany(u => u.ListUser).Inverse().Cascade.All().KeyColumn("GroupUsers");
        }
    }
}
