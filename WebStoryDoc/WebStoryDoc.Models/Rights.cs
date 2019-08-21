using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;


namespace WebStoryDoc.Models
{
    public class Rights
    {
        public virtual Folder Folder { set; get; }
        public virtual string Level { set; get; }
        public virtual GroupUsers GroupUser { set; get; }
        public virtual User User { set; get; }
    }

    public class RightsMap : ClassMap<Rights>
    {
        public RightsMap()
        {
            Map(u => u.Folder);
            Map(u => u.Level).Length(100);
            Map(u => u.GroupUser);
            Map(u => u.User);
        }
    }
}
