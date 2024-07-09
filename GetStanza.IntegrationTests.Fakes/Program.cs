using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using GetStanza.IntegrationTests.Fakes;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await CreateHostBuilder(args).Build().RunAsync();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host
            .CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>().ConfigureKestrel(options =>
                {
                    options.Listen(IPAddress.Any, 5000,
                        listenOptions => { listenOptions.Protocols = HttpProtocols.Http2; });
                });
            });
    }
}