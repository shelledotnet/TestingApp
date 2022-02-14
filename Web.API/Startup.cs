using Core.DataStore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.API.Filters;
using Web.API;

namespace Test.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }

        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _env;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureCors();
            services.ConfigureMapper();
            services.AddControllers(options =>
            {

                #region Adding Filter Globally that affect all controllers
                //options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                //options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status405MethodNotAllowed));
                //options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status406NotAcceptable));
                //options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                //options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status503ServiceUnavailable));
                //options.Filters.Add<Version1DiscontinueResourceFilter>();
                options.Filters.Add<DtoStateValidatorActionFilter>();
                //options.Filters.Add<CreateTicketDto_ValidateDateActionFilter>(); // this action filter only affect one action method there4 it should not be globally
                #endregion

                //which tells the server that if the client tries to negotiate for the Accept header media type the server doesn’t support
                //, it should return the 406 Not Acceptable status code.
                options.ReturnHttpNotAcceptable = true;

                // options.OutputFormatters.Add(new XmlSerializerOutputFormatter());

            })
            ////for custom response on the model
            .ConfigureApiBehaviorOptions(options =>
            {

                options.SuppressModelStateInvalidFilter = true;
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Test.API", Version = "v1" });
            });
            if (_env.IsDevelopment())
            {
                services.AddDbContext<BugsContext>(options =>
                {
                    options.UseInMemoryDatabase("Bugs");
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,BugsContext bugsContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Test.API v1"));


                //create in-memory databse for dev environment
                bugsContext.Database.EnsureDeleted();
                bugsContext.Database.EnsureCreated();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
