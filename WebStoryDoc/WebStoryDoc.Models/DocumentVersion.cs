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
        public virtual ulong Id { set; get; }
        public virtual string File { set; get; } //Путь к файлу (?)
        public virtual string Author { set; get; }
        public virtual DateTime Date { set; get; }
        public virtual Folder Document { set; get; }
    }

    public class DocumentVersionMap : ClassMap<DocumentVersion>
    {
        public DocumentVersionMap()
        {
            Id(u => u.Id).GeneratedBy.HiLo("0");
            Map(u => u.File).Length(1000);
            References(u => u.Author).Column("Author");
            Map(u => u.Date);
            Map(u => u.Document);
        }
    }
}
