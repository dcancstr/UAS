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
    public class PersonelRolTipMap : BaseMap<PersonelRolTip, int>
    {
        public override void Configure(EntityTypeBuilder<PersonelRolTip> builder)
        {
            base.Configure(builder);

            builder.Property(prt => prt.personelRolTipAd)
                .IsRequired(false)
                .HasColumnType("varchar(300)");

            builder.Property(prt => prt.personelRolTipSMI)
                .IsRequired(true)
                .HasColumnType("bit");

            builder.Property(prt => prt.personelRolTipColor)
                .IsRequired(false)
                .HasColumnType("varchar(50)");

            builder.Property(prt => prt.personelRolTipIndexUrl)
                .IsRequired(true)
                .HasColumnType("int");

            //relations 
            // builder.HasMany(prt => prt.GrupMenuPanels).WithOne(gmp => gmp.PersonelRolTip).HasForeignKey(gmp => gmp.personelRolTipID);
        }
    }
}
