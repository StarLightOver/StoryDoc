using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class Folder
    {
        public virtual ulong Id { set; get; }
        public virtual string Name { set; get; }
    }

    public class FolderMap : ClassMap<Folder>
    {
        public FolderMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.Name).Length(100);
        }
    }
}
