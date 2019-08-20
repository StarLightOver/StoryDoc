using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    class Document : Folder
    {
        public virtual string TypeDocument { set; get; }
        public virtual DateTime Date { set; get; }
        public virtual string Author { set; get; }
    }
}
