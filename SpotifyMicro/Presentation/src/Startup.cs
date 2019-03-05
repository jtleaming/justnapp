using System;
using Application.Interfaces;
using Application.Tracks;
using Domain;
using Infrastructure.Interfaces;
using Infrastructure.Network;
using Infrastructure.SpotifyServices;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Env = env;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment Env { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var config = new WebConfig();
            var authenticationService = new AuthenticationService();

            Configuration.GetSection("webConfig").Bind(config);

            services.AddSingleton<IGetTracksQuery, GetTracksQuery>();
            services.AddSingleton<ITrackService, TrackService>();
            services.AddSingleton<IAuthenticationService>(authenticationService);
            services.AddSingleton<IWebClientWrapper>(new WebClientWrapper(config, authenticationService));
            services.AddSingleton<ITrackInfo, TrackInfo>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


            services.AddCors(options =>
            {
                Console.WriteLine("Starting Cors");
                if (Env.IsDevelopment())
                {
                    options.AddPolicy("DevPolicy", policy =>
                            // policy.WithOrigins("http://localhost:3006")
                            //     .WithMethods("Get")
                            //     .AllowAnyHeader());
                            policy.AllowAnyHeader()
                                .AllowAnyOrigin()
                                .AllowAnyMethod());
                }
                else
                {
                    options.AddDefaultPolicy(policy =>
                            policy.AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowAnyOrigin());
                }
            });
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

            // app.UseHttpsRedirection();
            app.UseCors("DevPolicy");
            app.UseMvc();
        }
    }
}
