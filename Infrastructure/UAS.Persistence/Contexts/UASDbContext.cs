using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Repositories;
using UAS.Domain.Entities;
using UAS.Domain.Entities.Common;
using System.Reflection;
using UAS.Persistence.ConfigurationMap;

namespace UAS.Persistence.Contexts
{
    public class UASDbContext : IdentityDbContext<AppUser, AppRole, int, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public UASDbContext(DbContextOptions<UASDbContext> options) : base(options)
        {
        }



        public DbSet<MenuKategori> MenuKategories { get; set; }
        public DbSet<MenuPanel> MenuPanels { get; set; }
        public DbSet<GrupMenuPanel> GrupMenuPanels { get; set; }
        public DbSet<PersonelRolTip> PersonelRolTips { get; set; }
        public DbSet<PersonelRol> PersonelRols { get; set; }
        public DbSet<SiteSetting> SiteSettings { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(Persistence.ConfigurationMap.AppUserMap)));
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity<int>>();
            foreach (var data in datas)
            {
                switch (data.State)
                {
                    case EntityState.Detached:
                        break;
                    case EntityState.Unchanged:
                        break;
                    case EntityState.Deleted:
                        break;
                    case EntityState.Modified:
                        data.Entity.EDate = DateTime.Now;
                        break;
                    case EntityState.Added:
                        data.Entity.CDate = DateTime.Now;
                        //data.Entity.Id = UniqueId.GetUniqueId;
                        break;
                    default:
                        break;
                }
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
