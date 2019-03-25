using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KestraTest.Business;
using KestraTest.Contracts.Business;
using KestraTest.Contracts.DataAccess;
using KestraTest.Contracts.Repository;
using KestraTest.DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace KestraTest.Api
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder =>
                    {
                        builder
                        .AllowAnyOrigin();
                    });
            });

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Autoalert ChatMeter", Version = "v1" });
            });

            var connectionString = Startup.Configuration["connectionStrings:KestraStudentDBConnectionString"];
            services.AddDbContext<KestraStudentContext>(o => o.UseSqlServer(connectionString));
            services.AddScoped<IStudentGradeRepository, StudentGradeRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IStudentGradeBusiness, StudentGradeBusiness>();
            services.AddScoped<IStudentReportBusiness, StudentReportBusiness>();
            services.AddScoped<ISubjectBusiness, SubjectBusiness>();
            services.AddScoped<IStringsToolsBusiness, StringsToolsBusiness>();
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

            app.UseSwagger();

            // Shows UseCors with named policy.
            app.UseCors("AllowAll");

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kestra Test");
            });            

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
