using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MF.Models.Helper;
using MF.Models.Mappings;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Npgsql;

namespace MF.Models.Entities
{
    public class Team
    {
        public virtual int TeamId { get; protected set; }
        public virtual string TeamName { get; set; }

        public static void Add(Team newTeam)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(newTeam);
                    transaction.Commit();
                }
            }
        }
        public static IList<Team> GetAllTeams()
        {
            using (ISession session = Methods.OpenSession())
            {
                try
                {
                    var result = session.CreateCriteria<Team>().List<Team>();
                    return result ?? new List<Team>(); 
                }
                catch (Exception ex)
                {
                    //supress
                }

                return new List<Team>(); 
            }
        }
        public static Team GetTeamByName(string name)
        {
            using (ISession session = Methods.OpenSession())
            {
                //can throw nonuniqueresult exception
                var result = session.QueryOver<Team>().Where(x => x.TeamName == name).SingleOrDefault();
                return result ?? new Team();
            }
        }
        public static Team GetTeamById(int teamId)
        {

            using (ISession session = Methods.OpenSession())
            {
                var result = session.QueryOver<Team>().Where(x => x.TeamId == teamId).SingleOrDefault();
                return result ?? new Team();
            }
        }

        public static void Update(Team newTeam)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(newTeam);
                    transaction.Commit();
                }
            }
        }

        //ToD0 > Read http://ayende.com/blog/1890/nhibernate-cascades-the-different-between-all-all-delete-orphans-and-save-update
        public static void Delete(Team team)
        {
            using (ISession session = Methods.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(team);
                    transaction.Commit();
                }
            }
        }

        public override string ToString()
        {
            return string.Format("[Team > {0}, {1}]", TeamId, TeamName);
        }
    }
}
