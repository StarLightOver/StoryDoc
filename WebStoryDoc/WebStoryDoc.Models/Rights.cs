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
        public virtual long Id { set; get; }
        public virtual Folder Folder { set; get; }
        public virtual string Level { set; get; }
        public virtual GroupUsers GroupUser { set; get; }
        public virtual Person User { set; get; }
    }

    public class RightsMap : ClassMap<Rights>
    {
        public RightsMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            References(u => u.Folder).Cascade.SaveUpdate();
            Map(u => u.Level).Length(100);
            References(u => u.GroupUser).Cascade.SaveUpdate();
            References(u => u.User).Cascade.SaveUpdate();
        }
    }
}
