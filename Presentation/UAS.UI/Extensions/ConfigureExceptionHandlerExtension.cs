using Microsoft.AspNetCore.Diagnostics;

using Serilog.Context;

using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace UAS.API.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        public static void ConfigureExceptionHandler<T>(this WebApplication application, Serilog.ILogger logger)
        {
            //program.cs yerine burda çağırıyoruz her zaman program.cs'yi temiz tutmalıyız
            application.UseExceptionHandler
            (
                builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                        context.Response.ContentType = MediaTypeNames.Application.Json;
                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            LogContext.PushProperty("UserName", "TODO:UserName");
                            LogContext.PushProperty("Path", context.Request.Path);
                            LogContext.PushProperty("Method", context.Request.Method);
                            LogContext.PushProperty("IP", context.Connection.RemoteIpAddress);
                            logger.Error(contextFeature.Error, "{Message}", contextFeature.Error.Message);

                            await context.Response.WriteAsync(JsonSerializer.Serialize(new
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                                Title = "Hata!"
                            }));

                        }
                    });
                }
            );

        }
    }
}
