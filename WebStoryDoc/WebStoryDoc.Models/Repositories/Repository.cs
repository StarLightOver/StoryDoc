﻿using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebStoryDoc.Models.Filters;

namespace WebStoryDoc.Models.Repositories
{
    public class Repository<T, F> : IRepository
        where T:class
        where F:BaseFilter
    {
        protected ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public virtual T Load(long id)
        {
            return session.Get<T>(id);
        }

        public virtual void Save(T entity)
        {
            using (var tran = session.BeginTransaction())
            {
                try
                {
                    session.Save(entity);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
            
        }

        public virtual void Delete(long id)
        {
            

            using (var tran = session.BeginTransaction())
            {
                try
                {
                    var item = session.Get<T>(id);

                    session.Delete(item);
                    tran.Commit();
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        public virtual IList<T> Find (F filter, FetchOptions fetchOptions = null)
        {
            var crit = session.CreateCriteria<T>();

            if (filter != null)
            {
                SetupFilter(crit, filter);
            }

            if (fetchOptions != null)
            {
                SetupFetchOptions(crit, fetchOptions);
            }

            return crit.List<T>();
        }

        protected virtual void SetupFetchOptions(ICriteria crit, FetchOptions fetchOptions)
        {
            if (!string.IsNullOrEmpty(fetchOptions.SortExpression))
            {
                crit.AddOrder(fetchOptions.SortDirection == SortDirection.Asc ?
                    Order.Asc(fetchOptions.SortExpression) :
                    Order.Desc(fetchOptions.SortExpression));
            }

            if (fetchOptions.First != null)
            {
                crit.SetFirstResult(fetchOptions.First.Value);
            }

            if (fetchOptions.Count != null)
            {
                crit.SetMaxResults(fetchOptions.Count.Value);
            }
        }

        protected virtual void SetupFilter(ICriteria crit, F filter)
        {
            if (filter.Id.HasValue)
            {
                crit.Add(Restrictions.IdEq(filter.Id.Value));
            }

            if (!string.IsNullOrEmpty(filter.SearchString))
            {
                var properties = typeof(T).GetProperties();

                AbstractCriterion clause = null;

                foreach (var property in properties)
                {
                    var fs = property.GetCustomAttribute<FastSearchAttribute>();
                    if (fs == null)
                    {
                        continue;
                    }

                    AbstractCriterion like;

                    switch (fs.FiledType)
                    {
                        case FiledType.Int:
                            var proj = Projections.Cast(NHibernateUtil.Int64, 
                                Projections.Property(property.Name));

                            like = Restrictions.InsensitiveLike(proj, filter.SearchString, MatchMode.Anywhere);
                            break;
                        default:
                            like = Restrictions.InsensitiveLike(property.Name, filter.SearchString, MatchMode.Anywhere);
                            break;
                    }

                    clause = clause == null ?
                        like :
                        Restrictions.Or(clause, like);
                }

                if (clause != null)
                {
                    crit.Add(clause);
                }
                
            }
        }

        public long Count()
        {
            return session.QueryOver<T>().RowCount();
        }

        public long CountMemory()
        {
            var crit = session.CreateCriteria<Document>();

            crit.SetProjection(Projections.Sum("FileSize"));

            return crit.UniqueResult<long>();
        }
    }
}
