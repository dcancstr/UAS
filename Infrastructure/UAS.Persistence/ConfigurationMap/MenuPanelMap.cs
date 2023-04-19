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
    public class MenuPanelMap : BaseMap<MenuPanel, int>
    {
        public override void Configure(EntityTypeBuilder<MenuPanel> builder)
        {
            base.Configure(builder);
            builder.Property(mp => mp.menuUstID);
            builder.Property(mp => mp.menuSira);
            builder.Property(mp => mp.menuIcon)
                .IsRequired(false)
                .HasColumnType("varchar(100)");
            builder.Property(mp => mp.menuAd)
                .IsRequired(false)
                .HasColumnType("varchar(200)");
            builder.Property(mp => mp.menuLink)
                .IsRequired(false)
                .HasColumnType("varchar(MAX)");
            builder.Property(mp => mp.menuVisible)
                .IsRequired(true)
                .HasColumnType("bit");
            builder.Property(mp => mp.menuSMI)
                .IsRequired(true)
                .HasColumnType("bit");

            builder.HasOne(mp => mp.MenuKategori).WithMany(mk => mk.MenuPanels).HasForeignKey(mp => mp.menuKategoriID);
        }
    }
}
