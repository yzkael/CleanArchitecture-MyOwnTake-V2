using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;

namespace Clean.Infrastructure.Configurations
{
    public class SerilogConfig
    {
        public static void ConfigureLogger(string logFilePath = "Logs/log.txt")
        {
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    path: logFilePath,
                    rollingInterval: RollingInterval.Day, // Create a new file daily
                    retainedFileCountLimit: 30, // Retain logs for 30 days
                    restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Warning // File: Warning and above)
                )
                .CreateLogger();
        }
    }
}