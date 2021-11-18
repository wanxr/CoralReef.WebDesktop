using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SpaServices.ViteJsDevServer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Vue3_Vite.Filters;
using Vue3_Vite.Authentication;
using Vue3_Vite.Entities;
using Vue3_Vite.Services;
using System.Text.Json.Serialization;

namespace Vue3_Vite
{
    public class Startup
    {
        private readonly bool isDeployAsWebApi = false;
        private readonly string corsPolicyName = "myPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            isDeployAsWebApi = Configuration.GetSection("DeployAsWebApi").Get<bool>();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(option =>
            {
                //option.Filters.Add(typeof(ApiAuthenticationAttribute));
                option.Filters.Add(typeof(ApiResponseFilterAttribute));
                option.Filters.Add(typeof(ApiExceptionFilterAttribute));
            }).AddJsonOptions(option =>
            {
                option.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            services.AddScoped<IAuthentication, JwtAuthentication>();
            services.AddScoped<IUserService, UserService>();

            services.Configure<TokenInfo>(Configuration.GetSection("TokenManagement"));
            var token = Configuration.GetSection("TokenManagement").Get<TokenInfo>();

            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token.Secret)),
                    ValidIssuer = token.Issuer,
                    ValidAudience = token.Audience,
                    ClockSkew = TimeSpan.Zero
                };
            });

            if (!isDeployAsWebApi)
            {
                // In production, the React files will be served from this directory
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });
            }
            else
            {
                services.AddCors(options =>
                {
                    options.AddPolicy(name: corsPolicyName, builder =>
                    {
                        builder.WithOrigins("http://localhost");
                        builder.AllowAnyHeader();
                        builder.AllowAnyMethod();
                    });
                });
            }

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "CoralReef.WebDesktop Vue3_Vite",
                    Description = "This is a hybrid application",
                    Contact = new OpenApiContact
                    {
                        Name = "前端开发组"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "No License"
                    }
                });
                options.TagActionsBy(apiDescription =>
                {
                    return new List<string>
                    {
                        apiDescription.HttpMethod
                    };
                });
                options.OrderActionsBy(apiDescription =>
                {
                    return apiDescription.RelativePath;
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\""
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
                // using System.Reflection;
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            if (!isDeployAsWebApi)
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            //app.UseMiddleware<JwtInterceptMiddleware>();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapControllerRoute(
                //    name: "default",
                //    pattern: "{controller}/{action=Index}/{id?}"
                //);
                endpoints.MapControllers();
            });

            if (!isDeployAsWebApi)
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseViteJsDevServer(npmScript: "dev");
                    }
                });
            }
            else
            {
                app.UseCors(corsPolicyName);
            }
        }
    }
}