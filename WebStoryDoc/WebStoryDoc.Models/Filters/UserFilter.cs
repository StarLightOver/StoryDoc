using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStoryDoc.Models.Filters
{
    public class UserFilter : BaseFilter
    {
        public string Login { get; set; }

        public  GroupUsers GroupUsers { set; get; }
        
        public Range<DateTime> CreationDate { get; set; }

        // Параметра для учебной фильтрации (Потом убрать - заменить)
        /*
        public string FIO { get; set; }

        public string Email { get; set; }

        public Range<int> Age { get; set; }

        public IList<Person> CreationAuthor { get; set; }
        */
    }
}
