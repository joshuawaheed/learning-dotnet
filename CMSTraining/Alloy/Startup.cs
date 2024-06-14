using Alloy.Extensions;
using EPiServer.Cms.Shell;
using EPiServer.Cms.UI.AspNetIdentity;
using EPiServer.Scheduler;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace Alloy
{
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

                services.Configure<SchedulerOptions>(options => options.Enabled = false);
            }

            services
                .AddCmsAspNetIdentity<ApplicationUser>()
                .AddCms()
                .AddFind() // enable Search & Navigation
                .AddAlloy()
                .AddAdminUserRegistration()
                .AddEmbeddedLocalization<Startup>();

            services.AddContentDeliveryApi(options =>
            { // enable Content Delivery API including sites
                options.SiteDefinitionApiEnabled = true;
            })
            .WithFriendlyUrl(); // enable friendly URLs

            services.AddContentSearchApi(options =>
            { // enable Content Search API and limit results
                options.MaximumSearchResults = 10;
            });

            // Required by Wangkanai.Detection
            services.AddDetection();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
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

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            // required for Content Search API
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapContent();
            });
        }
    }
}
