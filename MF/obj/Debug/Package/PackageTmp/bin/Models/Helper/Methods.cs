using System;
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

        private static void InitializeSessionFactory()
        {
            // read config default style
            var cfg = new Configuration();
            cfg.Configure(); 

            // add mappings
            //_sessionFactory = Fluently.Configure(cfg)
            //    .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(DbFile))
            //    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entities.Team>())
            //    .ExposeConfiguration(config => new SchemaExport(config).Execute(false, true, false))
            //    .BuildSessionFactory();

            const string conString = "workstation id=turnamentdata.mssql.somee.com;packet size=4096;user id=Password1;pwd=Password1;data source=turnamentdata.mssql.somee.com;persist security info=False;initial catalog=turnamentdata";
            _sessionFactory = Fluently.Configure(cfg)
                .Database(MsSqlCeConfiguration.Standard.ShowSql().ConnectionString(conString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entities.Team>())
                .ExposeConfiguration(config => new SchemaExport(config).Execute(false, true, false))
                .BuildSessionFactory();
        }
       

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
