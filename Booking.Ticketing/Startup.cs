using Booking.Ticketing.Dto;
using Booking.Ticketing.Import;
using Booking.Ticketing.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.IO;
using System.Reflection;

namespace Booking.Ticketing
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IConfigurationRoot configuration = GetConfiguration();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });
            services.AddRouting();

            services.Configure<CsvFileReaderConfiguration>(configuration.GetSection("CsvFileReaderConfiguration"));
            services.AddSingleton<ITicketingServices, TicketingServices>();

            services.AddTransient<CsvFileReader>();
            services.AddSingleton<IFileWatcherService, FileWatcherService>();

            var sp = services.BuildServiceProvider();
            var fileWatcherService = sp.GetService<IFileWatcherService>();
            var path = @"C:\\Users\\orhounilazaar\\Desktop\\ticket";
            //var path = sp.GetService<IOptions<CsvFileReaderConfiguration>>().Value.DirectoryPath;
            fileWatcherService.MonitorDirectory(path);


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Booking Ticketing API V1", Version = "v1" });
                c.IgnoreObsoleteActions();
                c.CustomSchemaIds(p => p.FullName);
            });
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            #region Swagger
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            //TODO Get virtual directory dynamicly  - BUG Swagger ->https://github.com/domaindrivendev/Swashbuckle/issues/305
            app.UseSwagger(c =>
            {
                //c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.BasePath = "/booking-integrator-api");
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.BasePath = "");
            });



            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("./v1/swagger.json", "Booking Ticketing API V1");
            //});
            #endregion
        }

        private static IConfigurationRoot GetConfiguration()
        {
            //configuration
            string environment = GetEnvironment();

            //setup
            var configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
               .AddJsonFile("appsettings.json", optional: true);
            configuration.AddEnvironmentVariables();

            return configuration.Build();
        }

        private static string GetEnvironment()
        {
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (String.IsNullOrWhiteSpace(environment))
                Console.WriteLine("Environment: {0}", "no defined");
            else Console.WriteLine("Environment: {0}", environment);
            return environment;
        }
    }
}
