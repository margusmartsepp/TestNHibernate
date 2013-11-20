using FluentNHibernate.Testing;
using NHibernate;
using NHibernateFootballChampionshipTests.Entities;
using NHibernateFootballChampionshipTests.Helper;
using NUnit.Framework;

//PM> Install-Package NUnit
//PM> Install-Package NHibernate
//PM> Install-Package FluentNHibernate
namespace NHibernateFootballChampionshipTests.nUnit
{
    /// <summary>
    /// create an Team instance
    /// insert the Team into the database
    /// retrieve the record into a new Team instance
    /// verify the retrieved Team matches the original
    /// </summary>
    [TestFixture]
    class TeamTest
    {
        [Test]
        public static void CanCorrectlyMapTeamTest()
        {
            using (ISession session = Methods.OpenSession())
                new PersistenceSpecification<Team>(session)
                    .CheckProperty(c => c.TeamId, 1)
                    .CheckProperty(c => c.TeamName, "Margus")
                    .VerifyTheMappings();
        }
    }
}
