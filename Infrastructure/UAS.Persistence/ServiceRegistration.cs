using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UAS.Application.Abstractions.Services;
using UAS.Application.Repositories;
using UAS.Application.Repositories.Notification;
using UAS.Application.Repositories.NotificationCategory;
using UAS.Domain.Entities;
using UAS.Persistence.Contexts;
using UAS.Persistence.Repositories;
using UAS.Persistence.Repositories.Notification;
using UAS.Persistence.Repositories.NotificationCategory;
using UAS.Persistence.Services;
using UAS.Application.Repositories.PersonelRol;
using UAS.Persistence.Repositories.PersonelRol;
using UAS.Application.Repositories.PersonelRolTip;
using UAS.Persistence.Repositories.PersonelRolTip;
using UAS.Application.Repositories.GrupMenuPanel;
using UAS.Persistence.Repositories.GrupMenuPanel;
using UAS.Application.Repositories.MenuKategori;
using UAS.Persistence.Repositories.MenuKategori;
using UAS.Application.Repositories.MenuPanel;
using UAS.Persistence.Repositories.MenuPanel;
using UAS.EnvironmentConfiguration;

namespace UAS.Persistence
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection services)
        {
            
            services.AddDbContext<UASDbContext>(options => options.UseSqlServer(Configuration.ConnectionString), ServiceLifetime.Scoped);
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<UASDbContext>()
            .AddDefaultTokenProviders();


            #region Repositories
            services.AddScoped<ITestReadRepository, TestReadRepository>();
            services.AddScoped<ITestWriteRepository, TestWriteRepository>();
            services.AddScoped<INotificationReadRepository, NotificationReadRepository>();
            services.AddScoped<INotificationWriteRepository, NotificationWriteRepository>();
            services.AddScoped<INotificationCategoryReadRepository, NotificationCategoryReadRepository>();
            services.AddScoped<INotificationCategoryWriteRepository, NotificationCategoryWriteRepository>();
            services.AddScoped<ISiteSettingReadRepository, SiteSettingReadRepository>();
            services.AddScoped<ISiteSettingWriteRepository, SiteSettingWriteRepository>();
            services.AddScoped<IPersonelRolReadRepository,PersonelRolReadRepository>();
            services.AddScoped<IPersonelRolWriteRepository, PersonelRolWriteRepository>();
            services.AddScoped<IPersonelRolTipReadRepository, PersonelRolTipReadRepository>();
            services.AddScoped<IPersonelRolTipWriteRepository, PersonelRolTipWriteRepository>();
            services.AddScoped<IGrupMenuPanelReadRepository, GrupMenuPanelReadRepository>();
            services.AddScoped<IGrupMenuPanelWriteRepository, GrupMenuPanelWriteRepository>();
            services.AddScoped<IMenuKategoriReadRepository, MenuKategoriReadRepository>();
            services.AddScoped<IMenuKategoriWriteRepository, MenuKategoriWriteRepository>();
            services.AddScoped<IMenuPanelReadRepository, MenuPanelReadRepository>();
            services.AddScoped<IMenuPanelWriteRepository, MenuPanelWriteRepository>();

            #endregion

            #region Services
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IRedisCacheService, RedisCacheService>();
            services.AddScoped<EnvironmentConfig>();

            #endregion
        }
    }
}
