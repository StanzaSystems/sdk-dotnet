using GetStanza.IntegrationTests.Fakes.Services;

namespace GetStanza.IntegrationTests.Fakes;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddGrpc();
        services.AddGrpcReflection();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            if (env.IsDevelopment())
            {
                endpoints.MapGrpcReflectionService();
            }
            endpoints.MapGrpcService<ConfigService>();
            endpoints.MapGrpcService<QuotaService>();
            endpoints.MapGet(
                "/",
                () =>
                    "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909"
            );
        });
    }
}
