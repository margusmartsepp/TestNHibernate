using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using FluentNHibernate.Cfg.Db;
using MF.Models.Helper;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace MF.Models.Entities
{
    public class Result
    {
        public virtual int ResultId { get; protected set; }
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
        public static IList<Result> GetAllResults()
        {
            using (ISession session = Methods.OpenSession())
            {
                var result = session.CreateCriteria<Result>().List<Result>();
                return result ?? new List<Result>();
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
                    var remove = Result.GetResultById(result.ResultId);
                    remove.ResultFirst = null;
                    remove.ResultSecond = null;
                    session.Update(remove);
                    session.Delete(remove);
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
