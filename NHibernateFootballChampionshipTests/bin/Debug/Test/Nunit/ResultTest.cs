using System;
using System.Collections;
using FluentNHibernate.Testing;
using NHibernateFootballChampionshipTests.Entities;
using NHibernateFootballChampionshipTests.Helper;
using NUnit.Framework;

//PM> Install-Package NUnit
//PM> Install-Package NHibernate
//PM> Install-Package FluentNHibernate
namespace NHibernateFootballChampionshipTests.Test.Nunit
{
    /// <summary>
    /// create an Result instance
    /// insert the Result into the database
    /// retrieve the record into a new Result instance
    /// verify the retrieved Result matches the original
    /// </summary>
    [TestFixture]
    class ResultTest
    {
        [Test]
        public static void CanCorrectlyMapResultTest()
        {
            using (var session = Methods.OpenSession())
            {
                new PersistenceSpecification<Result>(session, new ResultComparer())
                    .CheckProperty(c => c.ResultId, 1)
                    .CheckReference(c => c.ResultFirst, new Team { TeamName = "Team1" })
                    .CheckReference(c => c.ResultSecond, new Team { TeamName = "Team2" })
                    .CheckProperty(c => c.ResultFirstScore, 1)
                    .CheckProperty(c => c.ResultSecondScore, 5)
                    .VerifyTheMappings();
            }
        }

        private class ResultComparer : IEqualityComparer
        {
            public bool Equals(object x, object y)
            {
                if (x == null || y == null)
                    return false;
                if (x is Result && y is Result)
                {
                    var xr = (Result)x;
                    var yr = (Result)y;
                    if (xr != yr)
                        return false;
                    if (xr.ResultFirst != null && yr.ResultFirst != null)
                        if (xr.ResultFirst.TeamId != yr.ResultFirst.TeamId)
                            return false;
                    if (xr.ResultSecond != null && yr.ResultSecond != null)
                        if (xr.ResultSecond.TeamId != yr.ResultSecond.TeamId)
                            return false;
                    if (xr.ResultFirstScore != yr.ResultFirstScore)
                        return false;
                    if (xr.ResultSecondScore != yr.ResultSecondScore)
                        return false;
                }

                return true;
            }

            public int GetHashCode(object obj)
            {
                throw new NotImplementedException();
            }
        }
    }
}
