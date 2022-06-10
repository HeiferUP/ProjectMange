﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace ProjectMange
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
            services.AddControllers();
            /*配置JWT认证中心*/
            //读取一波配置文件
            var validAudience = Configuration["audience"];
            var validIssuer = Configuration["issuer"];
            var securityKey = Configuration["HS256SecurityKey"];

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30),
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = validAudience,//Audience
                        ValidIssuer = validIssuer,//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey))
                    };
                });
            //配一波Swaager
            services.AddSwaggerGen(c =>
            {
                #region 可以不要
                //c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                //{
                //    Title = "ProjectMangeApi",
                //    Version = "v1.0",
                //    Description = "Asp.Net Core ProjectMangeApi",
                //    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                //    {
                //        Name = "ProjectMange",
                //        Email = "",
                //    }
                //});
                #endregion

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description= "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}",
                    Name= "Authorization",
                    In= ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中),
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {   
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {Id = "Bearer",Type = ReferenceType.SecurityScheme}
                        },Array.Empty<string>()
                    }
                });
                // 获取xml文件名
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                // 获取xml文件路径
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //启动Swagger注释
                c.IncludeXmlComments(xmlPath, true);
            });
            
        }

        /// <summary>
        /// Autofac配置
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="Exception"></exception>
        public void ConfigureContainer(ContainerBuilder builder)
        {
            try
            {
                var interceptorServiceTypes = new List<Type>();
                var assemblyServices = Assembly.Load("ProjectMange.Services");
                builder.RegisterAssemblyTypes(assemblyServices)
                    .AsImplementedInterfaces()
                    .InstancePerDependency()
                    //接口拦截
                    .EnableInterfaceInterceptors()
                    .InterceptedBy(interceptorServiceTypes.ToArray());
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message + "\n" + ex.InnerException);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            //认证中间件
            app.UseAuthentication();
            //授权中间件
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            //启用Swagger中间件
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "test v1"));

        }
    }
}
