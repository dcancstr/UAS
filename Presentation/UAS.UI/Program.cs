using UAS.Application;
using UAS.Infrastructure.Services.Storage.Local;
using UAS.Infrastructure;
using UAS.Persistence;
using UAS.API.Extensions;
using UAS.UI;
using UAS.UI.Middlewares;
using UAS.Application.Dto.SiteSettings;
using Microsoft.Extensions.Hosting.WindowsServices;
using UAS.Application.Utilities.Helpers;
using UAS.Domain.Entities.Configuration;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using UAS.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using UAS.EnvironmentConfiguration;
using UAS.UI.Models.Configuration;
using UAS.Application.UasServerConfiguration;

var builder = WebApplication.CreateBuilder(args);
EnvironmentConfig env = new(builder.Configuration);
//test


//bu ayar appsettings.json dosyasındaki herhangi bir güncellemede programa runtimede yansıtılmasını sağlar
builder.Configuration.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Core/UAS.EnvironmentConfiguration")).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
// options pattern read and write(with extensions method) appsettings.json
builder.Services.Configure<SiteSettingsUpload>(builder.Configuration.GetSection("SiteSettingsUpload")); // read // IOptionsSnapshot<T>
builder.Services.ConfigureWritable<SiteSettingsUpload>(builder.Configuration.GetSection("SiteSettingsUpload")); // write // IWritableOptions<T>





// Add services to the container.
builder.Services.AddPersistenceServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration, env);
builder.Services.AddStorage<LocalStorage>();
builder.Services.AddUIServices(builder.Configuration, env);
builder.Services.AddDbContext<UASDbContext>(options => options.UseSqlServer(EnvironmentConfig.GetConnectionString("localDb")));
var settings = new UASAppSettings(env);
builder.Services.AddSingleton(settings);

//Configure host services
builder.ConfigureSeriLog
    (
        connectionString: settings.ConnectionString
    );





string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins, policy =>
    {
        //policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin()// Her isteyen apiye istek gönderebilir.
        policy.WithOrigins("http://localhost:4200", "https://localhost:4200").AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddControllersWithViews().AddNToastNotifyToastr().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<Serilog.ILogger>());//Bir middleware devreye soktuk
//, app.Services.GetRequiredService<IHttpContextAccessor>()

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors(MyAllowSpecificOrigins);//cors politikasý middleware

app.UseMiddleware<CheckJwtMiddleware>();// her istekte access token validasyon yapar invalidate ise refresh token ile access token almaya çalýþýr refresh token yok ise giriþ sayfasýna yönlendirilir

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.UseNToastNotify();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller}/{action}/{id?}",
            defaults: new { controller = "Users", action = "GetAllUsers" });
});

app.Run();
