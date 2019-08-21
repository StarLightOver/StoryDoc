using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class User
    {
        public virtual ulong Id { set; get; }
        public virtual string Login { set; get; }
        public virtual string Password { set; get; }
        public virtual GroupUsers Group { set; get; }
        public virtual IList<Document> ListDocument { set; get; }

        public User()
        {
            ListDocument = new List<Document>();
        }
    }

    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.Login).Length(30).Not.Nullable();
            Map(u => u.Password).Length(30).Not.Nullable();
            References(u => u.Group).Column("GroupUsers");
            HasMany(u => u.ListDocument).Inverse().Cascade.All().KeyColumn("Author");
        }
    }

}
