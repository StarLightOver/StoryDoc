using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models
{
    public class User
    {
        public virtual ulong Id { set; get; }
        public virtual string Login { set; get; }
        public virtual string Password { set; get; }
        public virtual ulong Group { set; get; }
    }
}
