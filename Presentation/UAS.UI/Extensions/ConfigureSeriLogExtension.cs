using System.Collections.ObjectModel;
using System.Data;

using Serilog;
using Serilog.Core;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace UAS.API.Extensions
{
    static public class ConfigureSeriLogExtension
    {
        public static void ConfigureSeriLog(this WebApplicationBuilder webApplicationBuilder,
                                            string connectionString = null,
                                            WriteTo[] loggers = null)
        {
            var loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Error()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Fatal);
            loggerConfiguration = WriteToOptions(loggerConfiguration, loggers, connectionString);

            Logger log = loggerConfiguration.CreateLogger();

            try
            {
                //Log.Information("Starting up");
                //webApplicationBuilder.Logging.ClearProviders();
                //webApplicationBuilder.Logging.AddSerilog(log);
                object value = webApplicationBuilder.Host.UseSerilog(log);
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private static LoggerConfiguration WriteToOptions(LoggerConfiguration loggerConfiguration, WriteTo[] loggers, string connectionString)
        {
            loggers = loggers ?? new WriteTo[]
            {
                //Default loggers
            };

            if (connectionString is not null)
            {
                var columnOptions = ColumnOptions();
                loggerConfiguration = loggerConfiguration.WriteTo.MSSqlServer
                (
                    connectionString: connectionString,
                    sinkOptions: new MSSqlServerSinkOptions { TableName = "LogEvents", AutoCreateSqlTable = true },
                    columnOptions: columnOptions
                );
            }
            
            foreach (var logger in loggers)
            {
                loggerConfiguration = logger switch
                {
                    WriteTo.Console => loggerConfiguration.WriteTo.Console(),

                    WriteTo.Debug => loggerConfiguration.WriteTo.Debug(),

                    WriteTo.File => loggerConfiguration.WriteTo.File("default.txt"),

                    _ => loggerConfiguration
                };
            }

            return loggerConfiguration;
        }

        private static ColumnOptions ColumnOptions()
        {
            ColumnOptions columnOptions = new()
            {
                AdditionalColumns = new Collection<SqlColumn>
                {
                    //new SqlColumn
                    //    {ColumnName = "EnvironmentUserName", PropertyName = "UserName", DataType = SqlDbType.NVarChar, DataLength = 64},

                    //new SqlColumn
                    //    {ColumnName = "UserId", DataType = SqlDbType.BigInt, NonClusteredIndex = true},

                    new SqlColumn {ColumnName = "UserName", PropertyName="UserName", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},
                    new SqlColumn {ColumnName = "IP", PropertyName="IP", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},
                    new SqlColumn {ColumnName = "Method", PropertyName="Method", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},
                    new SqlColumn {ColumnName = "Path", PropertyName="Path", DataType = SqlDbType.NVarChar, DataLength = -1, AllowNull = true},

                },

            };
            columnOptions.Store.Remove(StandardColumn.Properties);
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);

            return columnOptions;
        }

    }

    public enum WriteTo
    {
        Console,
        File,
        Debug
    }
}
