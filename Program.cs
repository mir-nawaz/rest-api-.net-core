
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using restCore.Common;

namespace restCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
        .ConfigureAppConfiguration((builderContext, config) =>
        {
            IHostingEnvironment env = builderContext.HostingEnvironment;
            new Config(env);
        })
        .UseKestrel()
        .UseStartup<Startup>();
    }
}
