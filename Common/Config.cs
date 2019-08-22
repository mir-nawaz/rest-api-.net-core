
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace restCore.Common
{
    public class Config
    {
       public static IConfiguration get { get; set; }
       
        public Config(IHostingEnvironment env){

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            get = builder.Build();
            
        }
        
    }
}
