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
        public virtual DateTime Date { set; get; }
        public virtual string Author { set; get; }
    }

    public class DocumentMap : ClassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.TypeDocument).Length(100);
            Map(u => u.Date);
            Map(u => u.Author).Length(100);
        }
    }
}
