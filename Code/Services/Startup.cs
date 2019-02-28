using MichaelSoft.BugFree.WebApi.DataMappers;
using MichaelSoft.BugFree.WebApi.Entities;
using MichaelSoft.BugFree.WebApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MichaelSoft.BugFree.WebApi.Utils;
using MichaelSoft.BugFree.WebApi.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace MichaelSoft.BugFree.WebApi
{
    public class Startup
    {
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, ILogger<Startup> logger)
        {
            Configuration = configuration;
            _logger = logger;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation("Application started");

            services.AddCors();
            services.AddMvc( 
                opt => opt.Filters.Add<LoggingFilter>()
            ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);
            var bugDbConnStr = Configuration.GetConnectionString("BugDbConnStr");
            services.AddDbContext<BugDbContext>(options => options.UseSqlServer(bugDbConnStr));

            services.AddDbContext<SecurityDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SecurityDbConnStr")));


            //services.AddIdentity<AppUser, IdentityRole>()
            services.AddDefaultIdentity<AppUser>().AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SecurityDbContext>();

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    //AuthenticationType = System.Security.Claims.ClaimTypes.Authentication,
                    //NameClaimType = System.Security.Claims.ClaimTypes.Name,
                    //RoleClaimType = System.Security.Claims.ClaimTypes.Role,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,

                   
                };
            });

            // configure DI for application services
            services.AddScoped<IBugService, BugService>();

            DataMapper.Map(); // Set data mapper

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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            // global cors policy
            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            
            app.UseMvc();
        }
    }
}
