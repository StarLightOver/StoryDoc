using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class DocumentVersion
    {
        public virtual long Id { set; get; }
        public virtual byte[] FileContent { set; get; }
        public virtual Person Author { set; get; }
        public virtual DateTime Date { set; get; }
        public virtual Folder Document { set; get; }
    }

    public class DocumentVersionMap : ClassMap<DocumentVersion>
    {
        public DocumentVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.FileContent).Length(1000);
            References(u => u.Author).Cascade.SaveUpdate();
            Map(u => u.Date);
            References(u => u.Document).Cascade.SaveUpdate();
        }
    }
}
