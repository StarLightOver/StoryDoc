using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    class Rights
    {
        public virtual ulong Folder { set; get; }
        public virtual string Level { set; get; }
        public virtual ulong GroupUser { set; get; }
        public virtual ulong User { set; get; }
    }
}
