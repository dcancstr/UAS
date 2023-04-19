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
    public class GrupMenuPanelMap : BaseMap<GrupMenuPanel,int>
    {
        public override void Configure(EntityTypeBuilder<GrupMenuPanel> builder)
        {
            //base.Configure(builder);


            //builder.Ignore(x => x.Id);
            builder.HasKey(x => x.Id);

            //builder.HasKey(x => new { x.menuID, x.personelRolTipID });

            builder.Property(gmp => gmp.grupMenuSMI).IsRequired(true);

            //relations
            //builder.HasOne(gmp => gmp.MenuPanel).WithMany(mp => mp.GrupMenuPanels).HasForeignKey(gmp => gmp.menuID);
        }
    }
}
