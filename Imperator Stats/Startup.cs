using System;
using ImperatorStats.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ImperatorStats
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
            services.AddControllersWithViews();
            services.AddDbContext<ImperatorContext>(options =>
               options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddRazorPages().AddRazorRuntimeCompilation();
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = 
                    ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseForwardedHeaders();
            //app.Use(async (context, next) =>
            //{
            //    if (context.Request.IsHttps || context.Request.Headers["X-Forwarded-Proto"] == Uri.UriSchemeHttps)
            //    {
            //        await next();
            //    }
            //    else
            //    {
            //        string queryString = context.Request.QueryString.HasValue ? context.Request.QueryString.Value : string.Empty;
            //        var https = "https://" + context.Request.Host + context.Request.Path + queryString;
            //        context.Response.Redirect(https);
            //    }
            //});
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
          //  app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
