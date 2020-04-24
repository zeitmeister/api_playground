using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Treehouse.AspNetCore.Data;
using Treehouse.AspNetCore.Services;
using Treehouse.AspNetCore.Models;
using RestApiWrapper;
using Treehouse.AspNetCore.ViewModels.AuthModel;
using Treehouse.AspNetCore.Repositories;

namespace Treehouse.AspNetCore
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
          
            services.AddHttpClient("nhl", c => c.BaseAddress = new Uri("https://statsapi.web.nhl.com/api/v1/teams"));
            services.AddControllersWithViews();
            services.AddDbContext<PlayerContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("PlayerContext")));
            services.Configure<UserDatabaseSettings>(
                Configuration.GetSection(nameof(UserDatabaseSettings)));
            services.AddSingleton<IUserDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<UserDatabaseSettings>>().Value);
            services.AddSingleton<IBaseAuthModel, BaseAuthModel>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IQuestionRepository, QuestionRespository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IQuestionService, QuestionService>();
            services.AddHostedService<TimedUpdateTeamPointsService>();
            services.AddScoped<ITimedUpdateService, TimedUpdateTeamPointsService>();
            services.AddSingleton<IRestApiRequesterService, RestApiRequesterService>();
            services.AddScoped<ITestService, TestService>();
            services.AddSingleton<ICheckAuthHostedService, CheckAuthHostedService>();

            
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseAuthorization();
            
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
