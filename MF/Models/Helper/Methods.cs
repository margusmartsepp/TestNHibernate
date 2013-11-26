using System;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace MF.Models.Helper
{
    static class Methods
    {
        private const string DbFile = "App_Data\\DB.sdf";
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        public static string strSafe(string str)
        {
            return HttpUtility.HtmlEncode(str);
        }
        public static int intSafe(string str)
        {
            return int.Parse(HttpUtility.HtmlEncode(str));
        }

        private static void InitializeSessionFactory()
        {
            //// read config default style
            //var cfg = new Configuration();
            //cfg.Configure(); 

            // add mappings
            //_sessionFactory = Fluently.Configure(cfg)
            //    .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(DbFile))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entities.Team>())
            //    .ExposeConfiguration(config => new SchemaExport(config).Execute(false, true, false))
            //    .BuildSessionFactory();

            _sessionFactory = Fluently.Configure()
                        .Database(PostgreSQLConfiguration.PostgreSQL82
                        .Raw("hbm2ddl.keywords", "auto")//none
                        .ConnectionString(c => c
                        .Host("localhost")
                        .Port(5432)
                        .Database("DB")
                        .Username("margusmartsepp")
                        .Password("margusmartsepp")))
                        .Mappings(x => x.FluentMappings.AddFromAssemblyOf<Entities.Team>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();
        }


        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
