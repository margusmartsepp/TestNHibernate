using FluentNHibernate.Mapping;

namespace MF.Models.Mappings
{
    class TeamMap : ClassMap<Entities.Team>
    {
        public TeamMap()
        {
            Id(x => x.TeamId);
            Map(x => x.TeamName);
        }
    }
}
