using System;
using NHibernateFootballChampionshipTests.Test.Custom;

//PM> Install-Package Nunit
//PM> Install-Package NHibernate
//PM> Install-Package FluentNHibernate
//Add reference to "System.Data.SqlServerCe" and set "Copy local" to true.
//"Hibernate.cfg.xml" and mappings must be embedded / copied to output
namespace NHibernateFootballChampionshipTests
{
    class Program
    {
        static void Main()
        {
            Custom.ResultCustomTest();
            Custom.TeamCustomTest();
            Console.ReadKey();
        }
    }
}
