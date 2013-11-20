using FluentNHibernate.Mapping;
using NHibernateFootballChampionshipTests.Entities;

namespace NHibernateFootballChampionshipTests.Mappings
{
    class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.TeamId);
            Map(x => x.TeamName);
        }
    }
}
