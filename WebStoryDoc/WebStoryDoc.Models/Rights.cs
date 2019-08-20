using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class Rights
    {
        public virtual ulong Folder { set; get; }
        public virtual string Level { set; get; }
        public virtual GroupUsers GroupUser { set; get; }
        public virtual User User { set; get; }
    }
}
