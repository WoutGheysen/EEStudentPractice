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
using Oefenplatform.WebAPI.Data;
using Oefenplatform.WebAPI.Repositories;
using Oefenplatform.WebAPI.Services.AutoMapper;

namespace Oefenplatform.WebAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<OefenplatformContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Oefenplatform")));
            services.AddScoped<SchoolUserRepository>();
            services.AddScoped<AssessmentDetailRepository>();
            services.AddScoped<ClassGroupRepository>();
            services.AddScoped<AssessmentRepository>();
            services.AddScoped<FeedbackRepository>();
            services.AddScoped<CourseCategoryRepository>();
            services.AddScoped<QuestionCategoryRepository>();
            services.AddScoped<QuestionRepository>();
            services.AddScoped<SchoolUserCategoryRepository>();
            services.AddScoped<WrongAnswerRepository>();
            services.AddScoped<YearGradeRepository>();
            services.AddScoped<AnswerRepository>();
            services.AddCors(options =>
            {
                // this defines a CORS policy called "default"
                options.AddPolicy("default", policy =>
                {
                    policy.WithOrigins("http://localhost:44321")
                        .AllowAnyHeader()
                        .AllowAnyOrigin()
                        .AllowAnyMethod();
                });
            });

            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfileConfiguration());
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
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
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseCors("default");
            app.UseMvc();
        }
    }
}
