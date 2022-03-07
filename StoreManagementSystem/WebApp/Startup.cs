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

            #region �̪ۨ`�JSingleton,Scoped,Transient ����
            /*
            Transient
                        �C���`�J�ɡA�����s new �@�ӷs����ҡC
            Scoped
                        �C�� Request �����s new �@�ӷs����ҡA�P�@�� Request ���޸g�L�h�֭� Pipeline ���O�ΦP�@�ӹ�ҡC�W�ҩҨϥΪ��N�O Scoped�C
            Singleton
                        �Q��Ҥƫ�N���|�����A�{���B������u�|���@�ӹ�ҡA��ĳ���{���޲z�ͩR�g���C
             */
            #endregion

            //�̪ۨ`�J --> �O���� DATA STORE 
            services.AddScoped<ICategoryRepository, CategoryInMemoryRepository>();
            //�̪ۨ`�J --> Use Cases & Repositories
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
