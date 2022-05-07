using Model.Core.Models.Entities;
using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace Model.Core.Models.Mapping
{
    public class LocationMap: ClassMapping<Location>
    {
        public LocationMap()
        {
            Lazy(true);
            Cache(x => x.Usage(CacheUsage.ReadWrite));

            Id(x => x.LocationID, map => map.Generator(Generators.Identity));
            Property(x => x.LocationName, map => { map.NotNullable(true); });
            Property(x => x.LocationState, map => { map.NotNullable(true); });
            Property(x => x.LocationCity, map => { map.NotNullable(true); });
            Property(x => x.LocationCountry, map => { map.NotNullable(true); });
            Property(x => x.LocationZip, map => { map.NotNullable(true); });
        }
    }
}