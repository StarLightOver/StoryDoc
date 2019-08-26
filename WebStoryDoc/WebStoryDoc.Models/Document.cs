using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class Document : Folder
    {
        public virtual string TypeDocument { set; get; }
        public virtual Person Author { set; get; }
    }

    public class DocumentMap : SubclassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.TypeDocument).Length(100);
            References(u => u.Author).Cascade.SaveUpdate();
        }
    }
}
