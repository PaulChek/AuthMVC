using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthMVC {
    public class Startup {
        public void ConfigureServices(IServiceCollection services) {
            services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", cong => {
                cong.Cookie.Name = "AuthMVC";
                cong.LoginPath = "/Authenticate";
            });

            services.AddControllersWithViews();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
