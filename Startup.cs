using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using testCaseReact.Data;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace testCaseReact
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
            services//.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddEntityFrameworkNpgsql().AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("DefaultDatabaseConnection")));

            //Setting authorization token
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt => {
                    opt.Authority = "{yourAuthorizationServerAddress}";
                    opt.Audience="{yourAudience}";
                });

            services
            .AddMvcCore(options =>
            {
                options.RequireHttpsPermanent = true;
                options.RespectBrowserAcceptHeader = true;
            })
            .AddFormatterMappings()
            .AddJsonFormatters();
            
            services.AddAutoMapper();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
