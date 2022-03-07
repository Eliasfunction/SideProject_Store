using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Data;
using Plugins.DataStore.InMemory;
using UseCases.DataStorePluginInterfaces;
using UseCases;

namespace WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton<WeatherForecastService>();

            #region 相依注入Singleton,Scoped,Transient 說明
            /*
            Transient
                        每次注入時，都重新 new 一個新的實例。
            Scoped
                        每個 Request 都重新 new 一個新的實例，同一個 Request 不管經過多少個 Pipeline 都是用同一個實例。上例所使用的就是 Scoped。
            Singleton
                        被實例化後就不會消失，程式運行期間只會有一個實例，建議讓程式管理生命週期。
             */
            #endregion

            //相依注入 --> 記憶體 DATA STORE 
            services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            //相依注入 --> Use Cases & Repositories
            services.AddTransient<IViewCategoriesUseCase, ViewCategoriesUseCase>();
            services.AddTransient<IAddCategoryUseCases, AddCategoryUseCases>();
            services.AddTransient<IEditCategoryUseCases, EditCategoryUseCases>();
            services.AddTransient<IGetCategoryByIdUseCases, GetCategoryByIdUseCases >();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
