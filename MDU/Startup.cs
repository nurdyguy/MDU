using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MDU.Models;
using MDU.Services;
using MDU.Services.Contracts;
using MDU.Services.Implementtions;
using MDU.Repositories.Contracts;
using MDU.Repositories.Implementations;

using AccountService.Models;
using AccountService.Services.Contracts;
using AccountService.Services.Implementations;
using AccountService.Repositories.Contracts;
using AccountService.Repositories.Implementations;



namespace MDU
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddAuthentication("MDU")
                    .AddCookie("MDU", options =>
                    {
                        options.AccessDeniedPath = new PathString("/Error/404");
                        options.LoginPath = new PathString("/Account/Login");
                    });

            services.AddAuthorization(auth =>
            {
                auth.AddSecurity();
            });
                    

            services.AddMvc();

            RegisterDependencies(services);
            MathService.Calculators.Calculator.InitializeCalculator();

            Action<MDU.MDUOptions> mduOptions = (opt =>
            {
                opt.mduConnectionString = Configuration["ConnectionStrings:mduConnection"];
            });
            services.Configure(mduOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<MDUOptions>>().Value);

            Action<AccountService.AccountServiceOptions> acctOptions = (opt =>
            {
                opt.AppDBConnection = Configuration["ConnectionStrings:mduConnection"];
            });
            services.Configure(acctOptions);
            services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<AccountService.AccountServiceOptions>>().Value);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseStatusCodePagesWithRedirects("/Error/{0}");
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseAuthentication();
            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void RegisterDependencies(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            // services
            services.AddSingleton<IPokerService, PokerService>();
            services.AddSingleton<ICalculatorService, CalculatorService>();
            services.AddSingleton<IPropertySalesService, PropertySalesService>();

            // repositories
            services.AddSingleton<IPokerRepository, PokerRepository>();
            services.AddSingleton<IPropertySalesRepository, PropertySalesRepository>();
            services.AddSingleton<IUserDataService, UserDataService>();

            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserRoleRepository, UserRoleRepository>();

        }
    }
}
