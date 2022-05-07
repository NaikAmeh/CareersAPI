using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Model.Core.Models.Entities;

namespace Model.Core.Models.Mapping
{
    public class DepartmentMap : ClassMapping<Department>
    {
        public DepartmentMap()
        {
            Lazy(true);
            Cache(x => x.Usage(CacheUsage.ReadWrite));

            Id(x => x.DepartmentID, map => map.Generator(Generators.Identity));
            Property(x => x.DepartmentName, map => { map.NotNullable(true); });
        }
    }
}