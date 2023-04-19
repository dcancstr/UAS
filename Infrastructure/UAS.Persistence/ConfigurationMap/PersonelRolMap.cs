using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UAS.Domain.Entities;
using UAS.Persistence.ConfigurationMap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Persistence.ConfigurationMap
{
    public class PersonelRolMap : BaseMap<PersonelRol, int>
    {
        public override void Configure(EntityTypeBuilder<PersonelRol> builder)
        {
            //base.Configure(builder);

            builder.Ignore(x => x.Id);

            builder.HasKey(x => new { x.AppUserId, x.personelRolTipID });

            builder.Property(pr => pr.personelRolSMI)
                .IsRequired(true)
                .HasColumnType("bit");

            builder.Property(pr => pr.personelRolSira)
                .IsRequired(true)
                .HasColumnType("int");


            //builder.HasOne(pr => pr.AppUser).WithMany(au => au.PersonelRols).HasForeignKey(pr => pr.AppUserId);
            //builder.HasOne(pr => pr.PersonelRolTip).WithMany(prt => prt.PersonelRols).HasForeignKey(pr => pr.personelRolTipID);
        }
    }
}
