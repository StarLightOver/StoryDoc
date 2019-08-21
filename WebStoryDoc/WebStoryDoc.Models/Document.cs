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
        public virtual Folder Folder { get; set; }
    }

    public class DocumentMap : ClassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.TypeDocument).Length(100);
            Map(u => u.Date);
            References(u => u.Author).Column("Author");
            References(u => u.Folder).Column("Document");
        }
    }
}
