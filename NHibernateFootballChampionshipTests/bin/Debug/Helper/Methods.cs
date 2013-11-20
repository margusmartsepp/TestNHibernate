using System;
using NHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using NHibernateFootballChampionshipTests.Entities;

namespace NHibernateFootballChampionshipTests.Helper
{
    static class Methods
    {

        public static Guid ToGuid(int value)
        {
            var bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        private const string DbFile = "DB.sdf";
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

        private static void InitializeSessionFactory()
        {
            // read config default style
            var cfg = new Configuration();
            cfg.Configure(); 

            // add mappings
            _sessionFactory = Fluently.Configure(cfg)
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(DbFile))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Team>())
                .ExposeConfiguration(config => new SchemaExport(config).Execute(false, true, false))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
