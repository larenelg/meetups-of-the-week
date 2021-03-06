﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataDrivenDiversity.Api;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;

namespace DataDrivenDiversity
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddTransient<ApiKeyHandler>();

            services.AddRefitClient<IMeetupApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://api.meetup.com"))
                .AddHttpMessageHandler<ApiKeyHandler>();

            services.AddRefitClient<IStatsApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://nlp.localtest.me:6000"));

            services.AddRefitClient<INerApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("http://ner.localtest.me:9000"));

            services.AddRefitClient<IGenderApi>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://genderapi.io/api"))
                .AddHttpMessageHandler<GenderApiKeyHandler>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
