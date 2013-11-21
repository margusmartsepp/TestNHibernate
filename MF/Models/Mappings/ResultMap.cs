using FluentNHibernate.Mapping;
using MF.Models.Entities;

namespace MF.Models.Mappings
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
