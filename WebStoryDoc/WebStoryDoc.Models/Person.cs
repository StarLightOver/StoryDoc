using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryDoc.Models.Filters;

namespace WebStoryDoc.Models
{
    [Filter(Type = typeof(UserFilter))]
    public class Person
    {
        public virtual long Id { set; get; }
        
        public virtual string Login { set; get; }

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
            Map(u => u.Login).Length(30).Not.Nullable();
            Map(u => u.Password).Length(30).Not.Nullable();
            Map(u => u.CreationDate);
            Map(u => u.BirthDate);
            References(u => u.GroupUsers).Cascade.SaveUpdate();
        }
    }

}
