using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;



namespace FakeSO.API.Rest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
                 .UseOrleans(silo =>
                {    
                    silo.UseLocalhostClustering();
                    silo.ConfigureApplicationParts(parts =>
                    {
                         parts.AddApplicationPart(typeof(Program).Assembly).WithReferences().WithCodeGeneration();
                        
                    });
                    silo.AddSimpleMessageStreamProvider("SMSProvider");
                    silo.AddMemoryGrainStorage("PubStubStore");
                })
                 .ConfigureWebHostDefaults(webBuilder =>
                 {
                     webBuilder.UseStartup<Startup>();
                 });  
        


    }
}
