using System;
using System.Linq;

using AutoMapper;

using Lamar;

using MediatR;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Sigantha.Timeline.Queries;

namespace App.Sigantha.SystemWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureContainer(ServiceRegistry services)
        {
            services.AddControllers();

            services.Scan(s =>
            {
                s.TheCallingAssembly();
                s.WithDefaultConventions();
            });

            var assemblies =
                AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(s => s.GetName().Name.StartsWith(nameof(Sigantha)))
                    .ToArray();

            // Auto Mapper
            services.AddAutoMapper(assemblies);

            // Mediatr
            services.AddMediatR(assemblies);

            services.Scan(scanner =>
            {
                foreach (var assembly in assemblies)
                {
                    scanner.Assembly(assembly);
                }

                scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
            });

            // Need to add one for mediatr to see all of them
            services.For<IRequestHandler<TestQuery.Query, TestQuery.Temp>>().Use<TestQuery.Handler>();

            services.For<IMediator>().Use<Mediator>().Transient();
            services.For<ServiceFactory>().Use(ctx => ctx.GetInstance);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
