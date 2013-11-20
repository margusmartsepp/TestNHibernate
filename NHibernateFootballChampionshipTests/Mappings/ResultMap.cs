using FluentNHibernate.Mapping;
using NHibernateFootballChampionshipTests.Entities;

namespace NHibernateFootballChampionshipTests.Mappings
{
    class ResultMap : ClassMap<Result>
    {
        public ResultMap()
        {
            Id(x => x.ResultId);
            References(x => x.ResultFirst).Cascade.All();
            References(x => x.ResultSecond).Cascade.All();
            Map(x => x.ResultFirstScore);
            Map(x => x.ResultSecondScore);
        }
    }
}
