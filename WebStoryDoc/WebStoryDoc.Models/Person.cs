using FluentNHibernate.Mapping;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryDoc.Models.Filters;

namespace WebStoryDoc.Models
{
    [Filter(Type = typeof(UserFilter))]
    public class Person : IUser<long>
    {
        public virtual long Id { set; get; }
        
        public virtual string UserName { set; get; }

        public virtual string Password { set; get; }

        public virtual DateTime CreationDate { set; get; }

        public virtual DateTime BirthDate { set; get; }

        public virtual GroupUsers GroupUsers { set; get; }
        
    }

    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Table("UserTable");
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.UserName).Length(30).Not.Nullable();
            Map(u => u.Password).Length(500).Not.Nullable();
            Map(u => u.CreationDate);
            Map(u => u.BirthDate);
            References(u => u.GroupUsers).Cascade.SaveUpdate();
        }
    }

}
