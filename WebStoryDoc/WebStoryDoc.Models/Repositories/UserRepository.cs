using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebStoryDoc.Models.Filters;

namespace WebStoryDoc.Models.Repositories
{
    [Service]
    public class UserRepository : Repository<Person, UserFilter>
    {
        public UserRepository(ISession session) : base(session)
        {

        }

        public bool Exists(string login)
        {
            //Создаем запрос на проверку, есть ли такой логин в БД
            var crit = session.CreateCriteria<Person>()
                .Add(Restrictions.Eq("Login", login))
                .SetProjection(Projections.Count("Id"));

            //Получаем кол-во записей с таким логином. Конвертируем в int64 для дополнительной совместимости
            var count = Convert.ToInt64(crit.UniqueResult());

            return count > 0;
        }

        public IList<Person> GeAvgUsers()
        {
            var crit = session.CreateCriteria<Person>();

            //Создание подзапроса в БД
            var detachCriteria = DetachedCriteria.For<Person>()
                .SetProjection(Projections.Avg("Age"));

            crit.Add(Subqueries.PropertyGe("Age", detachCriteria));

            return crit.List<Person>();
        }

        public IEnumerable<GroupUsers> GroupUsersAll()
        {
            var resultGroupUsers = session.CreateCriteria<GroupUsers>().List<GroupUsers>();
            
            return resultGroupUsers;
        }

        protected override void SetupFilter(ICriteria crit, UserFilter filter)
        {
            base.SetupFilter(crit, filter);

            if (!string.IsNullOrEmpty(filter.Login))
            {
                crit.Add(Restrictions.Eq("Login", filter.Login));
            }

            // тестовые учебные фильтры
            /*
            if (!string.IsNullOrEmpty(filter.FIO))
            {
                crit.Add(Restrictions.InsensitiveLike("FIO", filter.FIO, MatchMode.Anywhere));
            }

            if (!string.IsNullOrEmpty(filter.Email))
            {
                crit.Add(Restrictions.Eq("Email", filter.Email));
            }
            */ 

            if (filter.CreationDate.From.HasValue)
            {
                crit.Add(Restrictions.Ge("CreationDate", filter.CreationDate.From.Value));
            }

            if (filter.CreationDate.To.HasValue)
            {
                crit.Add(Restrictions.Le("CreationDate", filter.CreationDate.To.Value));
            }

            /*
            if (filter.Age.From.HasValue)
            {
                crit.Add(Restrictions.Ge("CreationDate", filter.Age.From.Value));
            }

            if (filter.Age.To.HasValue)
            {
                crit.Add(Restrictions.Le("CreationDate", filter.Age.To.Value));
            }

            if (filter.CreationAuthor != null && filter.CreationAuthor.Count > 0)
            {
                crit.Add(Restrictions.In("CreationAuthor", filter.CreationAuthor.ToArray()));
            }
            */
        }
    }
}
