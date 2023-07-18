using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MVCDemoNetCore.Interface;
using MVCDemoNetCore.Models;
using MVCDemoNetCore.Repositories;

namespace MVCDemoNetCore
{
    // 新创建一个Startup类
    public class Startup
    {
        IConfiguration configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // 配置 - 注册依赖关系/服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false);
            // 指明哪个repository实现了接口
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
        }
        // 注册中间件 
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            // Configure the HTTP request pipeline.
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            /*
             * 1. 使用MVC默认路由  app.UseMvcWithDefaultRoute();
                2. 使用MVC的管道路径  可以在这里配置路由等操作
                2.1 指定默认controller
                    app.UseMvc(routes =>
                    {
                        routes.MapRoute(
                        name: "User",
                        template: "{controller}/{action}/{id?}",
                        defaults: new { controller = "User", action = "Index" });
                    });
                2.2 指定默认controller为default - 需要有传入id的方法
                    app.UseMvc(routes =>
                    {
                        routes.MapRoute(
                        name: "default",
                        template: "{controller}/{action=Index}/{id?}");
                    });
                    app.UseMvc(routes =>
                    {
                        routes.MapRoute(
                        name: "default",
                        template: "{controller=Home}/{action=Index}");
                    });
                3. 使用endpoints
                    app.UseEndpoints(endpoints =>
                    {
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                    });
                4. 或使用
                    app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}");
            */

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run();

        }
    }
}
