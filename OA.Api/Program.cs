using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using Microsoft.Extensions.Logging;
using OA.Data.Domain;
using OA.Repo;
using OA.Repo.Infrastructure;

namespace OA.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            /*
            var path = env.ContentRootPath;
            path = path + "\\Auth.json";

            newInstance = FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile(path)
            }, "myApp");             
             */
            var builder = CreateHostBuilder(args).Build();

            using (var scope = builder.Services.CreateScope())
            {

                
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();

                await scope.ServiceProvider.GetRequiredService<ProjectContext>().Database.MigrateAsync();
                await Seed.SeedApplicationData(roleManager, userManager);
            }
            await builder.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) {
            
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //webBuilder.UseKestrel(options => { options.Limits.MaxRequestBodySize = null; });
                });


            return host;
        }
    }
}
