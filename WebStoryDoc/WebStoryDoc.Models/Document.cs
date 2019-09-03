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

        public virtual long? FileSize { set; get; }

        public virtual byte[] FileContent { set; get; }
    }

    public class DocumentMap : SubclassMap<Document>
    {
        public DocumentMap()
        {
            Map(u => u.TypeDocument).Length(100);
            Map(u => u.FileSize);
            Map(u => u.FileContent).Length(int.MaxValue);
        }
    }
}
