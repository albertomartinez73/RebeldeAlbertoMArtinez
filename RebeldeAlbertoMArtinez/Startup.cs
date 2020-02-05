
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RebeldeAlbertoMArtinez.Services.Log;
using RebeldeAlbertoMArtinez.Services.RebeldeFactory;
using RebeldeAlbertoMArtinez.Services.RebeldeListFactory;
using RebeldeAlbertoMArtinez.Services.Repository;
using RebeldeAlbertoMArtinez.Services.SplitService;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RebeldeAlbertoMArtinez.Infraestructure_Transversal.Exceptions;

namespace RebeldeAlbertoMArtinez
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IHostingEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Controlo el tipo de archivo log dependiendo si es Develop o Production
            services.AddSingleton(typeof(ILog),
                Environment.IsDevelopment() ? typeof(EscribirLogConsole) : typeof(EscribirLogTxt));

            // Controlo el repository dpendiendo si es Develop o Production
            services.AddScoped(typeof(IRebeldeRepository),
                Environment.IsDevelopment() ? typeof(FakeRepository) : typeof(Repositorio));

            services.AddScoped(typeof(Services.RebeldeFactory.IRebeldeFactory), typeof(RebeldeFactory));
            services.AddScoped(typeof(IRebeldeListFactory), typeof(RebeldeListFactory));
            services.AddScoped(typeof(ISplitService), typeof(SplitService));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));  //Registro del Middleware
            app.UseMvc();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCookiePolicy();
            app.UseMvcWithDefaultRoute();
        }

        public class ErrorHandlingMiddleware
        {
            private readonly RequestDelegate next;
            public ErrorHandlingMiddleware(RequestDelegate next)
            {
                this.next = next;
            }

            public async Task Invoke(HttpContext context, IServiceProvider serviceProvider /* other dependencies */)
            {
                try
                {
                    await next(context);
                }
                catch (Exception ex)
                {
                    ILog log = serviceProvider.GetService<ILog>();
                    await HandleExceptionAsync(context, ex, log);
                }
            }

            private static Task HandleExceptionAsync(HttpContext context, Exception ex, ILog log)
            {
                var code = HttpStatusCode.InternalServerError; // 500 if unexpected


                if (ex is ExceptionControllerCreate) code = HttpStatusCode.BadRequest;
                else if (ex is ExceptionControllerGet) code = HttpStatusCode.BadRequest;
                else if (ex is SplitServiceException) code = HttpStatusCode.BadRequest;
                else if (ex is RebeldeFactoryException) code = HttpStatusCode.BadRequest;
                else if (ex is ValidationException) code = HttpStatusCode.BadRequest;
                else if (ex is RebeldeRepositoryException) code = HttpStatusCode.NotFound;

                var result = JsonConvert.SerializeObject(new { error = ex.Message });
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = (int)code;
                log.EscribirLog(result);
                return context.Response.WriteAsync(result);

            }
        }
    }
}
