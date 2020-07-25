using DevIO.Api.Extensions;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevIO.Api.Configuration
{
    public static class LogConfig
    {
        public static IServiceCollection AddLogginConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddCheck("Produtos", new SqlServerHealthCheck(configuration.GetConnectionString("DefaultConnection")))
                .AddSqlServer(configuration.GetConnectionString("DefaultConnection"), name: "BancoSql");

            services.AddHealthChecksUI();
             
            return services;
        }

        public static IApplicationBuilder UseLogginConfiguration(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/api/hc", new HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });

            app.UseHealthChecksUI(op => { op.UIPath = "/api/hc-ui"; });

            return app;
        }
    }
}
