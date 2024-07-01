using AlloyDemo.Extensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Labs.GridView;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Net.Http.Headers;

namespace AlloyDemo;

public class Startup
{
    private readonly IWebHostEnvironment _webHostingEnvironment;

    public Startup(IWebHostEnvironment webHostingEnvironment)
    {
        _webHostingEnvironment = webHostingEnvironment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        if (_webHostingEnvironment.IsDevelopment())
        {
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(_webHostingEnvironment.ContentRootPath, "App_Data"));

            // services.Configure<SchedulerOptions>(options => options.Enabled = false);
        }

        services
            .AddCmsAspNetIdentity<ApplicationUser>()
            .AddCms()
            .AddAlloy()
            .AddAdminUserRegistration()
            .AddEmbeddedLocalization<Startup>();

        // Required by Wangkanai.Detection
        services.AddDetection();

        services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromSeconds(10);
            options.Cookie.HttpOnly = true;
            options.Cookie.IsEssential = true;
        });

        services.AddTinyMceCustomizations();

        services.AddMaxMindGeolocationProvider(options =>
        {
            // Download link for MaxMind DB and Locations CSV:
            // https://dev.maxmind.com/geoip/geoip2/geolite2/
            var databaseFolderPath = @"C:\Work\Learning\Optimizely\CMSDemo\App_Data\";
            options.DatabasePath = databaseFolderPath + "GeoIP2-City.mmdb";
            options.LocationsDatabasePath = databaseFolderPath + "GeoIP2-City-Locations-en.csv";
        });

        services.AddGridView(options =>
        {
            //options.IsViewEnabled = true;
        });

        //services.AddResponseCaching();

        services.Configure<EPiServer.Shell.Modules.ProtectedModuleOptions>(options =>
        {
            options.RootPath = "~/secret";
        });

        services.Configure<EPiServer.Web.UIOptions>(options =>
        {
            options.EditUrl = new Uri("~/secret/cms", UriKind.Relative);
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        // Required by Wangkanai.Detection
        app.UseDetection();
        app.UseSession();

        app.UseStaticFiles(new StaticFileOptions
        {
            OnPrepareResponse = ctx =>
            {
                // seconds_per_minute * minutes_per_hour 
                // * hours_per_day * days_per_year
                const int seconds = 60 * 60 * 24 * 365;
                ctx.Context.Response.Headers[HeaderNames.CacheControl] =
                $"public,max-age={seconds}";
            }
        });

        app.UseRouting();
        app.UseAuthentication();
        app.UseAuthorization();
        
        //app.UseResponseCaching();
        //app.Use(async (context, next) =>
        //{
        //    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
        //    {
        //        Public = true,
        //        MaxAge = TimeSpan.FromSeconds(10)
        //    };

        //    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

        //    await next();
        //});

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapContent();
        });
    }
}
