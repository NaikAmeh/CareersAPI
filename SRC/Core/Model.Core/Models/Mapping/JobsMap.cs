using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using Model.Core.Models.Entities;
namespace Model.Core.Models.Mapping
{
    public class JobsMap : ClassMapping<Jobs>
    {
        public JobsMap()
        {
            Lazy(true);
            Cache(x => x.Usage(CacheUsage.ReadWrite));

            Id(x => x.JobID, map => map.Generator(Generators.Identity));
            Property(x => x.JobName, map => { map.NotNullable(true); });
            Property(x => x.JobCode, map => { map.NotNullable(true); });
            Property(x => x.JobDescription, map => { map.NotNullable(true); });
            Property(x => x.PostedDate, map => { map.NotNullable(true); });
            Property(x => x.ClosingDate, map => { map.NotNullable(true); });
            Property(x => x.IsActive, map => { map.NotNullable(true); });

            ManyToOne(x => x.JobDepartment, map => { map.Column("DepartmentID"); });
            ManyToOne(x => x.JobLocation, map => { map.Column("LocationID"); });
        }
    }
}