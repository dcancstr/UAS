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
    public class SiteSettingMap : BaseMap<SiteSetting, int>
    {
        public override void Configure(EntityTypeBuilder<SiteSetting> builder)
        {
            base.Configure(builder);

            builder.Property(ss => ss.SiteName).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.LogoUrl).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.LayoutImageUrl).HasColumnType("nvarchar(MAX)");

            builder.Property(ss => ss.SmsApiUrl).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.SmsApiId).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.SmsApiKey).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.SmsGonderici).HasColumnType("nvarchar(MAX)");

            builder.Property(ss => ss.MailSunucuAdresi).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.MailSunucuPortu).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.MailAdresi).HasColumnType("nvarchar(MAX)");
            builder.Property(ss => ss.MailSifresi).HasColumnType("nvarchar(MAX)");
        }
    }
}
