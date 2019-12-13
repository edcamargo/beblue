using System;
using System.IO;
using Beblue.Ioc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning.Conventions;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Beblue.Ui.Api
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            if (!Directory.Exists(@"c:\temp-ed"))
            {
                Directory.CreateDirectory(@"c:\temp-ed");
            }

            // Configuring the Swagger Documentation Service
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Documentação de Apis",
                        Version = "v1.0",
                        Description = "# Introducão\nSeja bem-vindo a documentação!\n\n\n"
                                      + "API desenvolvida utilizando o padrão REST, responsável por efetuar vendas de discos de vinil e calcular o valor de cashback.\n"
                                      + "Como usar a API?\n Logo a seguir você encontrará todos os recursos e metódos suportados pela API, sendo que essa página possibilita que você teste os recursos "
                                      + "e métodos diretamente através dela.",
                        Contact = new OpenApiContact
                        {
                            Name = "Edwin Camargo"
                        }
                    }
                    );
            });

            services.AddMvcCore(options => options.EnableEndpointRouting = false);

            services.AddApiVersioning(
                options =>
                {
                    // reporting api versions will return the headers "api-supported-versions" and "api-deprecated-versions"
                    options.ReportApiVersions = true;

                    options.DefaultApiVersion = new ApiVersion(new DateTime(2019, 12, 12));

                    // automatically applies an api version based on the name of the defining controller's namespace
                    options.Conventions.Add(new VersionByNamespaceConvention());
                });

            services.AddAuthentication();
            services.AddMvc().AddWebApiConventions();

            services.AddHttpContextAccessor();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvc().AddControllersAsServices();

            // Banco em memória
            // services.AddDbContext<BeblueContext>(options => options.UseInMemoryDatabase(databaseName: "dbBeblue"));

            services.AddDbContext<Repositories.Context.BeblueContext>(options => options.UseSqlite(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().AddWebApiConventions();
            services.AddSingleton<IConfiguration>(Configuration);

            DependencyInjection.InjecaoDependenciaRepositorios(ref services);
            DependencyInjection.InjecaoDependenciaServicos(ref services);
            DependencyInjection.InjecaoDependenciaConverters(ref services);
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
                app.UseExceptionHandler("/Home/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Ativando middlewares para uso do Swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Integration Api - Version 1.0");

                c.RoutePrefix = string.Empty;
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");

            app.UseMvc(routes =>
            {
                routes.MapRoute(name: "DefaultApi", template: "{controller=Values}/{id?}");
            });

            app.UseStaticFiles();

            app.UseMvc();
        }
    }
}
