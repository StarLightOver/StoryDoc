using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    class DocumentVersion
    {
        public virtual ulong Id { set; get; }
        public virtual string File { set; get; } //Путь к файлу (?)
        public virtual string Author { set; get; }
        public virtual DateTime Date { set; get; }
        public virtual ulong Document { set; get; }
    }
}
