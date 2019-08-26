using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryDoc.Models.Filters;

namespace WebStoryDoc.Models.Repositories
{
    [Service]
    public class GroupUsersRepository : Repository<GroupUsers, GroupUsersFilter>
    {
        public GroupUsersRepository(ISession session) : base(session)
        {

        }
    }
}
