using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UAS.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.ConfigurationMap.Common
{
    public abstract class BaseMap<T, TKey> : IEntityTypeConfiguration<T> where T : BaseEntity<TKey>
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn(1, 1);
            builder.Property(x => x.CDate).IsRequired(true);
            builder.Property(x => x.EDate).IsRequired(true);
            builder.Property(x => x.Deleted).IsRequired(true);
            builder.Property(x=> x.CreateUserIdentityId).IsRequired(true);
            builder.Property(x=> x.ChangeUserIdentityId).IsRequired(true);
            builder.Property(x=> x.RecordStatusId).IsRequired(true);
            builder.Property(x => x.RowVersion).IsRowVersion();
            builder.Property(x => x.IfTransferredToSecondary).IsRequired(true);
        }
    }
}
