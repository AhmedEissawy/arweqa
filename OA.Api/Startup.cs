using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OA.Api.Filters;
using OA.Api.MiddleWare;
using OA.Data;
using OA.Data.Domain;
using OA.Repo;
using OA.Repo.Implementation;
using OA.Repo.Interfaces;
using OA.Service.Implementation.AboutServices;
using OA.Service.Implementation.AdvertisementServices;
using OA.Service.Implementation.AnswerAttachmentServices;
using OA.Service.Implementation.AnswerServices;
using OA.Service.Implementation.BranchServices;
using OA.Service.Implementation.ExtraRequestServices;
using OA.Service.Implementation.Govern;
using OA.Service.Implementation.GradeServices;
using OA.Service.Implementation.Infrastructure;
using OA.Service.Implementation.LessonAttachmentServices;
using OA.Service.Implementation.LessonQuestionServices;
using OA.Service.Implementation.LessonServices;
using OA.Service.Implementation.LibraryServices;
using OA.Service.Implementation.MessageServices;
using OA.Service.Implementation.MzhbServices;
using OA.Service.Implementation.ReportServices;
using OA.Service.Implementation.RequestAttachmentServices;
using OA.Service.Implementation.RequestServices;
using OA.Service.Implementation.RoleServices;
using OA.Service.Implementation.SectionServices;
using OA.Service.Implementation.SemesterServices;
using OA.Service.Implementation.SocialLinkServices;
using OA.Service.Implementation.StageServices;
using OA.Service.Implementation.StudentLessonQuestionAnswerServices;
using OA.Service.Implementation.StudentServices;
using OA.Service.Implementation.SubjectGradeServices;
using OA.Service.Implementation.TeacherServices;
using OA.Service.Implementation.TeacherSubjectServices;
using OA.Service.Implementation.UnitServices;
using OA.Service.Implementation.UserServices;
using OA.Service.Interfaces;
using OA.Service.Interfaces.Infrastructure;
using OA.Service.Mapping;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OA.Api
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
            //Add Configuration for Automapper
            services.AddAutoMapper(typeof(MappingProfileBase));
            services.Configure<TwilioConfiguration>(opt => Configuration.GetSection("TwilioConfiguration").Bind(opt));
            services.AddSignalR();

            //Cors Configuration
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", configurePolicy =>
                {
                    configurePolicy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .WithOrigins(
                        "http://egabat-kw.com",
                        "http://localhost:4200",
                    "http://arweqa.algo-demo.com").AllowCredentials().SetIsOriginAllowedToAllowWildcardSubdomains();

                });
            });


            services.AddMvc(option =>
            {
                option.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
                option.EnableEndpointRouting = false;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            ConfigureDatabase(services);

            ConfigureOAuthuntication(services);

            ConfigureJWT(services);

            services.AddControllers();

            ConfigureRepositoriesTypes(services);

            ConfigureServiceTypes(services);

            ConfigureSwagger(services);

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseMiddleware<ErrorHandlingMiddleWare>();


            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseRouting();


            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<NotificationHub>("/hubs/Notification");
            });

            app.UseMvc();

            app.UseStaticFiles();


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();


            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

        }

        private void ConfigureOAuthuntication(IServiceCollection services)
        {

            services.AddIdentity<ApplicationUser, ApplicationRole>().AddEntityFrameworkStores<ProjectContext>().AddDefaultTokenProviders();

            // Identity Configuration
            var builder = services.AddIdentityCore<ApplicationUser>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

            }).AddRoles<ApplicationRole>().AddEntityFrameworkStores<ProjectContext>().AddDefaultTokenProviders();

            services.AddScoped<ActionFilter>();

        }


        private void ConfigureDatabase(IServiceCollection services)
        {
            // DbContext Configuration
            services.AddEntityFrameworkSqlServer();

            services.AddDbContextPool<ProjectContext>((serviceProvider, optionsBuilder) =>
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                optionsBuilder.UseInternalServiceProvider(serviceProvider);
            });
        }



        private void ConfigureRepositoriesTypes(IServiceCollection services)
        {
            services.AddTransient(typeof(IUserAccessor), typeof(UserAccessor));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IUserRepo), typeof(UserRepo));
            services.AddScoped(typeof(ISectionRepo), typeof(SectionRepo));
            services.AddScoped(typeof(IStageRepo), typeof(StageRepo));
            services.AddScoped(typeof(IGradeRepo), typeof(GradeRepo));
            services.AddScoped(typeof(ISubjectGradeRepo), typeof(SubjectGradeRepo));
            services.AddScoped(typeof(IStudentRepo), typeof(StudentRepo));
            services.AddScoped(typeof(ITeacherRepo), typeof(TeacherRepo));
            services.AddScoped(typeof(ITeacherSubjectRepo), typeof(TeacherSubjectRepo));
            services.AddScoped(typeof(IRequestRepo), typeof(RequestRepo));
            services.AddScoped(typeof(IRequestAttachmentRepo), typeof(RequestAttachmentRepo));
            services.AddScoped(typeof(IAnswerRepo), typeof(AnswerRepo));
            services.AddScoped(typeof(IAnswerAttachmentRepo), typeof(AnswerAttachmentRepo));
            services.AddScoped(typeof(IExtraRequestRepo), typeof(ExtraRequestRepo));
            services.AddScoped(typeof(IMessageRepo), typeof(MessageRepo));
            services.AddScoped(typeof(INotificationRepo), typeof(NotificationRepo));
            services.AddScoped(typeof(ISemesterRepo), typeof(SemesterRepo));
            services.AddScoped(typeof(IUnitRepo), typeof(UnitRepo));
            services.AddScoped(typeof(ILessonRepo), typeof(LessonRepo));
            services.AddScoped(typeof(ILessonAttachmentRepo), typeof(LessonAttachmentRepo));
            services.AddScoped(typeof(IAdvertisementRepository), typeof(AdvertisementRepository));
            services.AddScoped(typeof(ILibraryRepository), typeof(LibraryRepository));
            services.AddScoped(typeof(ILibraryTypeRepository), typeof(LibraryTypeRepository));
            services.AddScoped(typeof(ILessonQuestionRepo), typeof(LessonQuestionRepo));
            services.AddScoped(typeof(ILessonQuestionAnswerRepo), typeof(LessonQuestionAnswerRepo));
            services.AddScoped(typeof(IStudentLessonQuestionAnswerRepo), typeof(StudentLessonQuestionAnswerRepo));
            services.AddScoped(typeof(ISocialLinkRepo), typeof(SocialLinkRepo));
            services.AddScoped(typeof(IAboutRepository), typeof(AboutRepository));
            services.AddScoped(typeof(ILessonLiveVideoRepo), typeof(LessonLiveVideoRepo));
            services.AddScoped(typeof(ILessonLiveConnectionsRepo), typeof(LessonLiveConnectionRepo));
            services.AddScoped(typeof(IGovernRepo), typeof(GovernRepo));
            services.AddScoped(typeof(IMzhbRepo), typeof(MzhbRepo));
            services.AddScoped(typeof(IBranchRepo), typeof(BranchRepo));

        }


        private void ConfigureServiceTypes(IServiceCollection services)
        {
            services.AddScoped(typeof(IJwtGenerator), typeof(JwtGenerator));
            services.AddScoped(typeof(IFileHandler), typeof(FileHandler));
            services.AddScoped(typeof(IUserService), typeof(UserService));
            services.AddScoped(typeof(ISectionService), typeof(SectionService));
            services.AddScoped(typeof(IStageService), typeof(StageService));
            services.AddScoped(typeof(IGradeService), typeof(GradeService));
            services.AddScoped(typeof(ISubjectGradeService), typeof(SubjectGradeService));
            services.AddScoped(typeof(IStudentService), typeof(StudentService));
            services.AddScoped(typeof(ITeacherService), typeof(TeacherService));
            services.AddScoped(typeof(ITeacherSubjectService), typeof(TeacherSubjectService));
            services.AddScoped(typeof(IRequestService), typeof(RequestService));
            services.AddScoped(typeof(IRequestAttachmentService), typeof(RequestAttachmentService));
            services.AddScoped(typeof(IAnswerService), typeof(AnswerService));
            services.AddScoped(typeof(IAnswerAttachmentService), typeof(AnswerAttachmentService));
            services.AddScoped(typeof(INotificationService), typeof(NotificationService));
            services.AddScoped(typeof(IExtraRequestService), typeof(ExtraRequestService));
            services.AddScoped(typeof(IMessageService), typeof(MessageService));
            services.AddScoped(typeof(IRoleService), typeof(RoleService));
            services.AddScoped(typeof(IReportService), typeof(ReportService));
            services.AddScoped(typeof(ISemesterService), typeof(SemesterService));
            services.AddScoped(typeof(IUnitService), typeof(UnitService));
            services.AddScoped(typeof(ILessonService), typeof(LessonService));
            services.AddScoped(typeof(ILessonAttachmentService), typeof(LessonAttachmentService));
            services.AddScoped(typeof(IAdvertisementService), typeof(AdvertisementService));
            services.AddScoped(typeof(ILibraryService), typeof(LibraryService));
            services.AddScoped(typeof(ILessonQuestionService), typeof(LessonQuestionService));
            services.AddScoped(typeof(IStudentService), typeof(StudentService));
            services.AddScoped(typeof(IStudentLessonQuestionAnswerService), typeof(StudentLessonQuestionAnswerService));
            services.AddScoped(typeof(ISocialLinkService), typeof(SocialLinkService));
            services.AddScoped(typeof(IAboutService), typeof(AboutService));
            services.AddScoped(typeof(IOtpService), typeof(OtpService));
            services.AddScoped(typeof(IGovernService), typeof(GovernService));
            services.AddScoped(typeof(IMzhbService), typeof(MzhbService));
            services.AddScoped(typeof(IBranchService), typeof(BranchService));
            services.AddSingleton(typeof(ActiveUserTracker));
        }



        private void ConfigureSwagger(IServiceCollection services)
        {
            //Configure swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",

                    Title = "Answers Api ",

                    Description = "ASP.NET Core Web API for Answers Project",
                    TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "algorithm systems",
                        Email = string.Empty,
                        Url = new Uri("http://www.algorithm-eg.com"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                });
                //set jwt configuration with swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert JWT with Bearer into field",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.CustomSchemaIds(i => i.FullName);
            });
        }



        private void ConfigureJWT(IServiceCollection services)
        {
            //configure JWT 
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Secret"]));
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
                         ValidateIssuerSigningKey = true,
                         IssuerSigningKey = key,
                         ValidateIssuer = false,
                         ValidateAudience = false
                     };
                     x.Events = new JwtBearerEvents
                     {
                         OnMessageReceived = context =>
                     {
                         var accessToken = context.Request.Query["access_token"];
                         var path = context.Request.HttpContext.Request.Path;
                         if (!string.IsNullOrEmpty(accessToken) && (path.StartsWithSegments("/notification")))
                         {
                             context.Token = accessToken;
                         }
                         return Task.CompletedTask;
                     }

                     };

                 });
        }


    }
}
