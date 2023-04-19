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
    public class MenuKategoriMap : BaseMap<MenuKategori, int>
    {
        public override void Configure(EntityTypeBuilder<MenuKategori> builder)
        {
            base.Configure(builder);
            builder.Property(mk => mk.menuKategoriAd)
                .IsRequired(false)
                .HasColumnType("varchar(100)");
            builder.Property(mk => mk.menuKategoriSira)
                .IsRequired(true);



        }
    }
}
