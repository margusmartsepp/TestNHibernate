using NHibernateFootballChampionshipTests.Annotations;
using NHibernateFootballChampionshipTests.Helper;
using NHibernate;

namespace NHibernateFootballChampionshipTests.Entities
{
    public class Result
    {
        public virtual int ResultId { get; [UsedImplicitly] protected set; }
        public virtual Team ResultFirst { get; set; }
        public virtual Team ResultSecond { get; set; }
        public virtual int ResultFirstScore { get; set; }
        public virtual int ResultSecondScore { get; set; }


        public static void Add(Result newResult)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newResult);
                    transaction.Commit();
                }
            }
        }

        public static Result GetResultById(int resultId)
        {

            using (ISession session = Methods.OpenSession())
            {
                Team t1 = null;
                Team t2 = null;

                // do query
                var result = session.QueryOver<Result>()
                  .JoinAlias(x => x.ResultFirst, () => t1)
                  .JoinAlias(x => x.ResultSecond, () => t2)
                  .Where(x => x.ResultId == resultId)
                  .SingleOrDefault();
                return result ?? new Result();
            }
        }



        public static void Update(Result newResult)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(newResult);
                    transaction.Commit();
                }
            }
        }

        public static void Delete(Result result)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(result);
                    transaction.Commit();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("[Result[{0}] > {1} ({2} : {3}) {4}]",
                ResultId, ResultFirst==null ? "null" : ResultFirst.TeamName, ResultFirstScore, 
                ResultSecondScore, ResultSecond == null ? "null" : ResultSecond.TeamName);
        }
    }
}
